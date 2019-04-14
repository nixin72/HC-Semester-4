---
--- Sample showing:
--- 1)  variable types anchored to DB record type
--- 
---

DECLARE
   lv_first_name EMPLOYEES.FIRST_NAME%TYPE;
   lv_last_name EMPLOYEES.LAST_NAME%TYPE;
   lv_employee_id EMPLOYEES.EMPLOYEE_ID%TYPE;
   lv_hire_date EMPLOYEES.HIRE_DATE%TYPE;
BEGIN
   lv_first_name := 'Mary';
   lv_last_name := 'Jane';
   lv_hire_date := to_date('19700101','YYYYMMDD');
END;
/