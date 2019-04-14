--PL/SQL Hello World example
--DECLARE 
  --Block of code where you declare all your variables
--  text VARCHAR2(25);
--BEGIN
  --Where the work is actually done.
--  text := 'Hello World';
--  dbms_output.put_line(text);
--END;

SET SERVEROUTPUT ON SIZE 100000;
DECLARE 
  lv_fname NN_EMPLOYEE.fname%TYPE;
  lv_lname NN_EMPLOYEE.lname%TYPE;
  lv_employee_id NN_EMPLOYEE.EMPLOYEEID%TYPE;
  lv_salary NN_EMPLOYEE.salary%TYPE;
BEGIN
  SELECT employeeid, fname, lname, salary
    INTO lv_employee_id, lv_fname, lv_lname, lv_salary
  FROM nn_employee
  WHERE employeeid = 200;
  
  DBMS_OUTPUT.PUT_LINE(lv_fname || ' ' || lv_lname);
  DBMS_OUTPUT.PUT_LINE(to_char(lv_salary, '$999,999'));
END;
