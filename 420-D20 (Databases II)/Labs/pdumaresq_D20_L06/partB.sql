
CREATE OR REPLACE PACKAGE d20_l06_iu_faculty_pkg
IS
   PROCEDURE add_faculty_pp (
      pv_facultyid_i            iu_faculty.facultyid%TYPE,
      pv_name_i        IN       iu_faculty.NAME%TYPE,
      pv_deptname_i    IN       iu_department.deptname%TYPE,
      pv_building_o    OUT      iu_location.building%TYPE,
      pv_roomno_o      OUT      iu_location.roomno%TYPE,
      pv_success_o     OUT      CHAR
   );

   PROCEDURE list_department_pp (
      pv_deptname_i          iu_department.deptname%TYPE,
      pcur_faculty_o   OUT   sys_refcursor
   );
   
   PROCEDURE test_pkg;
END d20_l06_iu_faculty_pkg;


CREATE OR REPLACE PACKAGE BODY d20_L06_iu_faculty_pkg
IS
-- get an office that is currently available
   FUNCTION get_available_office_pf 
      return iu_location.roomid%TYPE IS
    lrec_first number;
   BEGIN
    SELECT DISTINCT l.roomid --into lrec_first
    FROM iu_location l
    WHERE l.capacity > (
      SELECT COUNT(roomid) 
        FROM iu_faculty f 
        WHERE f.roomid = l.roomid
      )
      AND l.roomtype = 'O'
      AND rownum = 1;
      
      return lrec_first;
   EXCEPTION 
    WHEN NO_DATA_FOUND THEN
      return null;
   END get_available_office_pf;

-- assign a faculty member to an available office
   PROCEDURE assign_office_pp (
      pv_facultyid_i         iu_faculty.facultyid%TYPE,
      pv_building_o    OUT   iu_location.building%TYPE,
      pv_roomno_o      OUT   iu_location.roomno%TYPE
   )
   IS
      lv_roomid           iu_location.roomid%TYPE;
      lv_current_roomid   iu_faculty.roomid%TYPE;
   BEGIN
      lv_roomid := get_available_office_pf;

      IF lv_roomid IS NOT NULL
      THEN
         SELECT building, roomno
           INTO pv_building_o, pv_roomno_o
           FROM iu_location
          WHERE roomid = lv_roomid;

         UPDATE iu_faculty
            SET roomid = lv_roomid
          WHERE facultyid = pv_facultyid_i;
      ELSE
         pv_building_o := NULL;                        -- no office available
      END IF;
   END assign_office_pp;

-- add a new faculty member
   PROCEDURE add_faculty_pp (
      pv_facultyid_i            iu_faculty.facultyid%TYPE,
      pv_name_i        IN       iu_faculty.NAME%TYPE,
      pv_deptname_i    IN       iu_department.deptname%TYPE,
      pv_building_o    OUT      iu_location.building%TYPE,
      pv_roomno_o      OUT      iu_location.roomno%TYPE,
      pv_success_o     OUT      CHAR
   )
   IS
      lv_deptid   iu_department.deptid%TYPE;
   BEGIN
      SELECT deptid
        INTO lv_deptid
        FROM iu_department
       WHERE UPPER (deptname) = UPPER (pv_deptname_i);

      INSERT INTO iu_faculty
                  (facultyid, NAME, deptid
                  )
           VALUES (pv_facultyid_i, pv_name_i, lv_deptid
                  );

      assign_office_pp (pv_facultyid_i, pv_building_o, pv_roomno_o);

      IF pv_building_o IS NULL
      THEN
         pv_success_o := 'U';
      ELSE
         pv_success_o := 'S';
      END IF;
   EXCEPTION
      WHEN OTHERS
      THEN
         pv_success_o := 'F';
   END;

-- list all the faculty in a department
   PROCEDURE list_department_pp (
      pv_deptname_i          iu_department.deptname%TYPE,
      pcur_faculty_o   OUT   sys_refcursor
   )
   IS
   BEGIN
      OPEN pcur_faculty_o
       FOR
          SELECT NAME, building || ' Room ' || roomno office, phone
            FROM iu_faculty JOIN iu_department USING (deptid) JOIN iu_location USING (roomid)
           WHERE UPPER (deptname) = UPPER (pv_deptname_i);
   END;
 
   PROCEDURE test_pkg IS
    lv_passed number := 0;
    lv_building  iu_location.building%TYPE;
    lv_roomno    iu_location.roomno%TYPE;
    lv_success   CHAR;
   BEGIN   
    add_faculty_pp(654, 'May', 'Computer Science', lv_building, lv_roomno, lv_success);
    lv_passed := CASE 
      WHEN lv_building = 'Heritage' AND lv_roomno = 217 AND lv_success = 'S' THEN
        lv_passed + 1
      ELSE lv_passed END;
    DBMS_OUTPUT.PUT_LINE('Building - Expected value: Heritage / Actual value: ' || lv_building );
    DBMS_OUTPUT.PUT_LINE('Room     - Expected value: 217      / Actual value: ' || lv_roomno );
    DBMS_OUTPUT.PUT_LINE('Success  - Expected value: S        / Actual value: ' || lv_success );
      
    add_faculty_pp(655, 'Trudeau', 'Computer Science', lv_building, lv_roomno, lv_success);
    lv_passed := CASE 
      WHEN lv_building is null AND lv_roomno is null AND lv_success = 'U' THEN
        lv_passed + 1
      ELSE lv_passed END;
    DBMS_OUTPUT.PUT_LINE('Building - Expected value: --       / Actual value: ' || lv_building );
    DBMS_OUTPUT.PUT_LINE('Room     - Expected value: --       / Actual value: ' || lv_roomno );
    DBMS_OUTPUT.PUT_LINE('Success  - Expected value: U        / Actual value: ' || lv_success );  
      
    add_faculty_pp(111, 'Jones', 'Computer Science', lv_building, lv_roomno, lv_success);
    lv_passed := CASE 
      WHEN lv_building is null AND lv_roomno is null AND lv_success = 'F' THEN
        lv_passed + 1
      ELSE lv_passed END;
    DBMS_OUTPUT.PUT_LINE('Building - Expected value: --       / Actual value: ' || lv_building );
    DBMS_OUTPUT.PUT_LINE('Room     - Expected value: --       / Actual value: ' || lv_roomno );
    DBMS_OUTPUT.PUT_LINE('Success  - Expected value: F        / Actual value: ' || lv_success );  
    
    add_faculty_pp(656, 'Mulcair', 'Information Science', lv_building, lv_roomno, lv_success);
    lv_passed := CASE 
      WHEN lv_building is null AND lv_roomno is null AND lv_success = 'F' THEN
        lv_passed + 1
      ELSE lv_passed END;
    DBMS_OUTPUT.PUT_LINE('Building - Expected value: --       / Actual value: ' || lv_building );
    DBMS_OUTPUT.PUT_LINE('Room     - Expected value: --       / Actual value: ' || lv_roomno );
    DBMS_OUTPUT.PUT_LINE('Success  - Expected value: F        / Actual value: ' || lv_success );    
    
    DBMS_OUTPUT.PUT_LINE('');
    DBMS_OUTPUT.PUT_LINE('Succeeded: ' || lv_passed);
    DBMS_OUTPUT.PUT_LINE('% Passed: ' || (lv_passed / 4) * 100);
    DBMS_OUTPUT.PUT_LINE('% Failed: ' || ((4-lv_passed) / 4) * 100);
   END;
END d20_L06_iu_faculty_pkg;

BEGIN
  D20_L06_IU_FACULTY_PKG.TEST_PKG;
END;

update iu_location
  set capacity = 1
  where roomid = 35;
