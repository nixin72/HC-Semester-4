---
--- Math example
--- Demonstrate:
--- 1) basic block structure
--- 2) basic output
--- 3) basic variable declaration and assignment
--- 4) coding standard for local variable (lv_)
SET serveroutput ON
DECLARE
  lv_double NUMBER;
  lv_num number;
BEGIN
  lv_num :=5;
  lv_double := lv_num * 2;
  dbms_output.put_line('Double of ' || 
  to_char(lv_num) || ' is ' || to_char(lv_double));
END;
/