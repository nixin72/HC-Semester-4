---
--- Sample showing:
--- 1)  constant in declaration
--- 2)  input in SQL*Plus
--- 3)  more math calculation
---
SET SERVEROUTPUT ON SIZE 1000000;
DECLARE
  lc_tip_percent            CONSTANT NUMBER (3, 2) := 0.15;
  lv_bill_food_total        NUMBER (4, 2)          := &food_total;
  lv_tip lv_bill_food_total %TYPE;
BEGIN
  lv_tip := lv_bill_food_total * lc_tip_percent;
  DBMS_OUTPUT.put_line ('Food total:     ' || TO_CHAR (lv_bill_food_total, '$9,999.99'));
  DBMS_OUTPUT.put_line ('Tip:  ' || TO_CHAR (lv_tip, '$9,999.99') );
END;
/