---
--- Hello World example
--- Demonstrate:
--- 1) basic block structure
--- 2) basic output
--- 3) basic variable declaration and assignment
SET serveroutput ON
DECLARE
  text VARCHAR2(25);
BEGIN
  text := 'Hello World';
  dbms_output.put_line(text);
END;
/