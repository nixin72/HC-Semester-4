---
--- Demonstrate %ROWTYPE
--- Note:
---   1) how the subfields are automatically determined based on the DB record
---   2) the dot notation for accessing the subfields (columns) 
---

DECLARE
   lrec_employee   nn_employee%ROWTYPE;
BEGIN
   SELECT *
     INTO lrec_employee
     FROM nn_employee
    WHERE employeeid = &employeeid;

   DBMS_OUTPUT.put_line (lrec_employee.lname);
   DBMS_OUTPUT.put_line (lrec_employee.fname);
   DBMS_OUTPUT.put_line (lrec_employee.salary);
END;
