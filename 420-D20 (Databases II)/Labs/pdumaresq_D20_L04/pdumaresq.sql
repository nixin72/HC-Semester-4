--------------------------------------------------------------------------------
------------------------------------PART A--------------------------------------
--------------------------------------------------------------------------------
SET SERVEROUTPUT ON;
DECLARE
   CURSOR lcur_manager
   IS
      SELECT d.deptid, e.employeeid, fname || ' ' || lname manager
        FROM nn_dept d 
        JOIN nn_employee e ON d.employeeid = e.employeeid;
        
  CURSOR lcur_emp (p_employeeid nn_employee.employeeid%TYPE, p_dept nn_dept.deptid%TYPE)
    IS 
    SELECT e.employeeid, e.deptid, e.fname || ' ' || e.lname AS name
      FROM nn_employee e
      WHERE e.employeeid != p_employeeid
        AND e.deptid = p_dept;
        
  lrec_emp lcur_emp%ROWTYPE;  
BEGIN
   FOR lrec_manager IN lcur_manager LOOP
      DBMS_OUTPUT.put_line ('Department: ' || lrec_manager.deptid
          || ' Manager: ' || lrec_manager.manager);
      
      OPEN lcur_emp (lrec_manager.employeeid, lrec_manager.deptid);
      FETCH lcur_emp INTO lrec_emp; 
      LOOP
        DBMS_OUTPUT.put_line ('Employeeid: ' || lrec_emp.employeeid
          || ' Name:   ' || lrec_emp.name);
            
        FETCH lcur_emp INTO lrec_emp;
        EXIT WHEN lcur_emp%NOTFOUND;
      END LOOP;
      CLOSE lcur_emp;
   END LOOP;
END;

--------------------------------------------------------------------------------
--------------------------------------PART B------------------------------------
--------------------------------------------------------------------------------
DECLARE
   lv_courseid       iu_course.courseid%TYPE      := UPPER ('&courseid');
   lv_studentid      iu_student.studentid%TYPE    := '&studentid';
   lv_name           VARCHAR2 (30);
   lv_final          iu_registration.FINAL%TYPE;
   lv_term           iu_crssection.termid%TYPE;
   lv_course_title   iu_course.title%TYPE;
   lv_err_msg       VARCHAR2(50)                 := 'SOMETHING';
BEGIN
   SELECT FIRST || ' ' || LAST
     INTO lv_name
     FROM iu_student
    WHERE studentid = lv_studentid;

   SELECT title
     INTO lv_course_title
     FROM iu_course
    WHERE courseid = lv_courseid;

   SELECT FINAL, termid
     INTO lv_final, lv_term
     FROM iu_registration JOIN iu_crssection USING (csid)
    WHERE courseid = lv_courseid AND studentid = lv_studentid;

   IF lv_final IN ('A', 'B', 'C', 'D', 'F')
   THEN
      DBMS_OUTPUT.put_line (   lv_name || ' got a grade of '
                            || lv_final || ' in '
                            || lv_course_title || ' in the '
                            || lv_term || ' term.' );
   ELSIF lv_final = 'W'
   THEN
      DBMS_OUTPUT.put_line (   lv_name || ' withdrew from '
                            || lv_course_title || ' in the '
                            || lv_term || ' term.'
                           );
   ELSIF lv_final IS NULL
   THEN
      DBMS_OUTPUT.put_line (   lv_name || ' is taking '
                            || lv_course_title || ' in the '
                            || lv_term || ' term.'
                           );
   END IF;
EXCEPTION  
  WHEN NO_DATA_FOUND THEN 
    IF lv_name IS NULL THEN
      lv_err_msg := lv_studentid || ' is not a valid student id';
    ELSIF lv_course_title IS NULL THEN
      lv_err_msg := lv_courseid || ' is not a valid course id';
    ELSE 
      lv_err_msg := lv_name || ' has not taken ' || lv_course_title;
    END IF;
    
    DBMS_OUTPUT.PUT_LINE(lv_err_msg);
  WHEN OTHERS THEN
    DBMS_OUTPUT.PUT_LINE(lv_name || ' has taken ' || lv_course_title || ' more than once.');
END;


--------------------------------------------------------------------------------
--------------------------------------PART C------------------------------------
--------------------------------------------------------------------------------
DECLARE
   TYPE lv_s       IS VARRAY(5) OF CHAR(5 BYTE);
   TYPE lv_c       IS VARRAY(5) OF VARCHAR2(6 BYTE);
   lv_studs        lv_s;
   lv_courses      lv_c;
BEGIN 
  lv_studs   := lv_s('00100',  '00104', '00105',  '00100',  '00106');
  lv_courses := lv_c('CIS253', 'AC101', 'CIS253', 'CIS254', 'CIS253');
  
  FOR x in 1..lv_studs.count LOOP 
    DECLARE 
      lv_courseid       iu_course.courseid%TYPE      := lv_courses(x);
      lv_studentid      iu_student.studentid%TYPE    := lv_studs(x);
      lv_name           VARCHAR2 (30);
      lv_final          iu_registration.FINAL%TYPE;
      lv_term           iu_crssection.termid%TYPE;
      lv_course_title   iu_course.title%TYPE;
      lv_err_msg        VARCHAR2(50)                 := 'SOMETHING';
    BEGIN
      SELECT FIRST || ' ' || LAST
        INTO lv_name
        FROM iu_student
        WHERE studentid = lv_studs(x);

      SELECT title
        INTO lv_course_title
        FROM iu_course
        WHERE courseid = lv_courses(x);

      SELECT FINAL, termid
        INTO lv_final, lv_term
        FROM iu_registration JOIN iu_crssection USING (csid)
        WHERE courseid = lv_courses(x) AND studentid = lv_studs(x);

      IF lv_final IN ('A', 'B', 'C', 'D', 'F')
        THEN
          DBMS_OUTPUT.put_line (   lv_name || ' got a grade of '
                            || lv_final || ' in '
                            || lv_course_title || ' in the '
                            || lv_term || ' term.' );
      ELSIF lv_final = 'W'
        THEN
          DBMS_OUTPUT.put_line (   lv_name || ' withdrew from '
                            || lv_course_title || ' in the '
                            || lv_term || ' term.'
                           );
      ELSIF lv_final IS NULL
      THEN
        DBMS_OUTPUT.put_line (   lv_name || ' is taking '
                            || lv_course_title || ' in the '
                            || lv_term || ' term.'
                           );
      END IF;
      
    EXCEPTION  
      WHEN NO_DATA_FOUND THEN 
        IF lv_name IS NULL THEN
          lv_err_msg := lv_studentid || ' is not a valid student id';
       ELSIF lv_course_title IS NULL THEN
          lv_err_msg := lv_courseid || ' is not a valid course id';
        ELSE 
          lv_err_msg := lv_name || ' has not taken ' || lv_course_title;
        END IF;
    
        DBMS_OUTPUT.PUT_LINE(lv_err_msg);
      WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE(lv_name || ' has taken ' || lv_course_title || ' more than once.');
    END;
  END LOOP;
END;


















