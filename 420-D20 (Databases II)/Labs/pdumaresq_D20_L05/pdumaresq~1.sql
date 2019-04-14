CREATE OR REPLACE PROCEDURE d20_L05_transfer_emp_sp (    
      pv_deptid_i     nn_dept.deptid%TYPE,
      pv_employeeid_i nn_employee.employeeid%TYPE   
  )
 IS
   e_no_such_dept   EXCEPTION;
   e_null_dept      EXCEPTION;
   PRAGMA EXCEPTION_INIT (e_no_such_dept, -2291);
   PRAGMA EXCEPTION_INIT (e_null_dept, -1407);
BEGIN
   UPDATE nn_employee
      SET deptid = pv_deptid_i
    WHERE employeeid = pv_employeeid_i;

   IF SQL%FOUND THEN
      DBMS_OUTPUT.put_line
                ('Update successful. Employee has been transferred');
   ELSE
      DBMS_OUTPUT.put_line 
                 ('Invalid employee number - does not exist.');
   END IF;
EXCEPTION
   WHEN e_no_such_dept THEN
      DBMS_OUTPUT.put_line ('Invalid dept id - does not exist');
   WHEN e_null_dept THEN
      DBMS_OUTPUT.put_line ('Deptid must be non-null.');
END d20_L05_transfer_emp_sp;

call d20_L05_transfer_emp_sp(20, 111) 

CREATE OR REPLACE PROCEDURE D20_L05_my_first_procedure_sp(
   pv_courseid_i             iu_course.courseid%TYPE,
   pv_course_title_o    OUT  iu_course.title%TYPE
)
IS
BEGIN
   SELECT title
     INTO pv_course_title_o
     FROM iu_course
    WHERE courseid = pv_courseid_i;
END D20_L05_my_first_procedure_sp;

CREATE OR REPLACE PROCEDURE D20_L05_get_student_mark_sp (
  pv_studentid        iu_student.student_id%TYPE,
  pv_csid             iu_crssection.csid%TYPE,
  pv_studentname  OUT iu_student.first%TYPE,
  pv_courseTitle  OUT iu_course.title%TYPE,
  pv_finalmark    OUT iu_registration.final%TYPE,
  pv_status       OUT iu_registration.regstatus%TYPE
)
AS
DECLARE 
  lv_status char;
BEGIN
  SELECT s.first || ' ' || s.last AS name, c.title as course, r.final, r.regstatus
  INTO pv_studentname, pv_courseTitle, pv_finalmark, pv_status, pv_status
  FROM iu_student s, iu_course c, iu_crssection crs, iu_registration r
  WHERE s.studentid = r.studentid
    AND r.csid      = crs.csid
    AND c.courseid  = crs.courseid
    AND s.studentid = pv_studentid
    AND r.csid      = pv_csid;
    
  if pv_finalmark is not null 
    then lv_status := 'C';
  elsif pv_finalmark is null 
    then if pv_status = 'R'
      then lv_status := 'T';
    elsif pv_status = 'X' 
      then lv_status := 'X';
    elsif pv_status = 'W'
      then lv_status := 'W';
    else
      lv_status := 'U';
    end if;
  else 
    lv_status := 'U';
  end if;
  
  pv_status := lv_status;  
EXCEPTION
  WHEN NO_DATA_FOUND 
    THEN DBMS_OUTPUT.PUT_LINE();
END D20_L05_get_student_mark_sp;

--call D20_L05_get_student_mark_sp(00100, 1104)

CREATE OR REPLACE PROCEDURE D20_L05_give_raise_sp (
  pv_percentage_raise_i in  number,
  pv_deptid_i           in  number DEFAULT null,
  pv_positionid_i       in  number DEFAULT null,  
  pv_num_employees_o    OUT number
)
AS  
BEGIN
  UPDATE nn_employee
    SET salary = salary * ((pv_percentage_raise_i/100)+1)
    WHERE deptid = pv_deptid_i
      AND positionid = pv_positionid_i;
   
  pv_num_employees_o := SQL%ROWCOUNT;
END;

 
CREATE OR REPLACE FUNCTION D20_L05_is_valid_department_sf (
  pv_deptid in number
)
return boolean
AS
  lv_rows number;
BEGIN
  SELECT count(*) into lv_rows
    FROM nn_Dept
    WHERE DEPTID = pv_deptid;
    
  if lv_rows > 0
    then return true;
  else 
    return false;
  end if;
END;

SET SERVEROUTPUT ON;
BEGIN 
  case D20_L05_is_valid_department_sf(99)
    WHEN true
      THEN DBMS_OUTPUT.PUT_LINE('True');
    WHEN false
      THEN DBMS_OUTPUT.PUT_LINE('False');
  END case;
  
    case D20_L05_is_valid_department_sf(10)
    WHEN true
      THEN DBMS_OUTPUT.PUT_LINE('True');
    WHEN false
      THEN DBMS_OUTPUT.PUT_LINE('False');
  END case;
END;



CREATE OR REPLACE FUNCTION D20_L05_CSID_capacity (
  pv_csid   in  iu_crssection.csid%TYPE
) 
return number
AS
  lv_per number;
BEGIN
  select count(r.csid) / crs.maxcount * 100 into lv_per
    from iu_crssection crs, iu_registration r
    where crs.csid = pv_csid
      AND R.CSID = crs.CSID
    group by crs.maxcount;

  return lv_per;
END;

declare
  cursor lcur_csid
    is select csid from iu_crssection;
    
  lv_per number;
begin 
  for x in lcur_csid loop
    lv_per := D20_L05_CSID_capacity(x.csid);
    DBMS_OUTPUT.PUT_LINE('CSID ' || x.csid || ': ' || lv_per);
  end loop;
end;






