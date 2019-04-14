--lv   : local variables
--lc   : local constant
--lrec : local records
--lcur : local cursor

--records create tables as variables. Kinda like an object.
SET serveroutput ON
DECLARE 
  lrec_employee nn_employee%rowtype;
BEGIN 
  SELECT *
    INTO lrec_employee
    FROM nn_employee
    WHERE EMPLOYEEID = &employeeid;
  
  DBMS_OUTPUT.put_line(lrec_employee.lname);
  DBMS_OUTPUT.put_line(lrec_employee.fname);
  DBMS_OUTPUT.put_line(lrec_employee.salary);
END;

--Mulitple rows saved as variables. 
DECLARE
  lrec_faculty iu_faculty%rowtype;
  lrec_location iu_location%rowtype;
BEGIN
  SELECT *
    INTO lrec_faculty
    FROM iu_faculty
  WHERE name = 'Jones';
  SELECT * 
    INTO lrec_location
    FROM iu_location
  WHERE roomid = 11;
    
  DBMS_OUTPUT.put_line(lrec_faculty.name);
  DBMS_OUTPUT.put_line(lrec_location.building);  
END;

--NOT FOUND EXAMPLE
DECLARE 
  lv_final iu_registration.FINAL%TYPE;
  lv_courseTitle iu_course.title%TYPE;
  lv_studentid iu_student.studentid%TYPE;
  lrec_student iu_student%ROWTYPE;
  
  CURSOR lcur_final
  IS SELECT studentid, FINAL
    FROM iu_registration WHERE csid = 1102;
BEGIN 
  --get the course title for course sectopn 1102
  --OPEN cursor;
  OPEN lcur_final;
  
  LOOP
    --FETCH lcur_final INTO lv_studentid, lv_final;
      --EXIT WHEN lcur_final%NOTFOUND;    
      --get the student record
      --display results
  END LOOP; 
  CLOSE lcur_final;
END;