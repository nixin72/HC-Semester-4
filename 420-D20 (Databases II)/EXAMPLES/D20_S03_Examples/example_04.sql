---
--- Sample showing:
--- 1)  variable types anchored to DB records
--- 2)  SQL query feeding into PL/SQL variable
----  (use of SELECT INTO)
---

SET SERVEROUTPUT ON SIZE 1000000;
DECLARE
   lv_first_name EMPLOYEES.FIRST_NAME%TYPE;
   lv_last_name EMPLOYEES.LAST_NAME%TYPE;
   lv_employee_id EMPLOYEES.EMPLOYEE_ID%TYPE;
   lv_hire_date EMPLOYEES.HIRE_DATE%TYPE;
BEGIN
   SELECT employee_id,
          first_name,
          last_name,
          hire_date
   INTO lv_employee_id,
        lv_first_name,
        lv_last_name,
        lv_hire_date
   FROM employees
   WHERE employee_id = 200;
 
   DBMS_OUTPUT.PUT_LINE(lv_first_name);
   DBMS_OUTPUT.PUT_LINE(lv_last_name);
   DBMS_OUTPUT.PUT_LINE(lv_hire_date);
END;
/