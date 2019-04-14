---
--- 
--- Demonstrate:
--- 1) user defined records
--- 
SET serveroutput ON
DECLARE
TYPE ltyp_employee
IS
  RECORD
  (
    lname VARCHAR2(15),
    fname VARCHAR2(15),
    sal   NUMBER(8,2));
  lrec_employee ltyp_employee;
BEGIN
---
--- Note that the order of the select fields MUST match the order of the 
--- record's fields
---

  SELECT lname,
    fname,
    salary
  INTO lrec_employee
  FROM NN_EMPLOYEE
  WHERE employeeId = 123;
  
  ---
  --- Note how the fields are referenced using the '.' notation
  ---
  dbms_output.put_line('Employee ' || lrec_employee.fname || ' ' ||
    lrec_employee.lname || ' has a salary of: '|| lrec_employee.sal);
END;