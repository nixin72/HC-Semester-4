--------------------------------------------------------------------------------
------------------------------------PART A--------------------------------------
--------------------------------------------------------------------------------
----------------------------NUMBER 1
SET DEFINE ON;
SET SERVEROUTPUT ON;
DECLARE 
  lv_num NUMBER;
  lv_char VARCHAR(25);
BEGIN
  lv_num := &EnterNumber;
  lv_char := '&EnterCharacter';
  
  IF (upper(lv_char) = 'S')
    THEN DBMS_OUTPUT.PUT_LINE(lv_num * lv_num);
  ELSIF (upper(lv_char) = 'C')
    THEN DBMS_OUTPUT.PUT_LINE(lv_num * lv_num * lv_num);
  ELSIF (upper(lv_char) = 'D')
    THEN DBMS_OUTPUT.PUT_LINE(lv_num * 2);
  ELSE 
    DBMS_OUTPUT.PUT_LINE('You obviously didnt get it...');
  END IF; 
END;

----------------------------NUMBER 2
DECLARE 
  lv_num NUMBER;
  lv_char VARCHAR(25);
BEGIN
  lv_num := &EnterNumber;
  lv_char := '&EnterCharacter';
  
  CASE upper(lv_char)
    WHEN 'S' 
      THEN DBMS_OUTPUT.PUT_LINE(lv_num * lv_num);
    WHEN 'C' 
      THEN DBMS_OUTPUT.PUT_LINE(lv_num * lv_num * lv_num);
    WHEN 'D' 
      THEN DBMS_OUTPUT.PUT_LINE(lv_num * 2);
    ELSE 
      DBMS_OUTPUT.PUT_LINE('You obviously didnt get it...');
  END CASE;
END;


----------------------------NUMBER 3
DECLARE 
  lv_fib1 number := 0;
  lv_fib2 number := 1;
  lv_tmp number;
  lv_count number := 0;
BEGIN
  WHILE lv_count < 20 LOOP
    DBMS_OUTPUT.PUT(lv_fib1 || ' ');
    
    lv_tmp := lv_fib2;
    lv_fib2 := lv_fib1 + lv_fib2;
    lv_fib1 := lv_tmp;
    lv_count := lv_count +1;
  END LOOP;
  DBMS_OUTPUT.NEW_LINE();
END;


----------------------------NUMBER 4  
BEGIN
  FOR lv_count IN REVERSE 0..10 LOOP
    DBMS_OUTPUT.PUT(lv_count || ' ');
  END LOOP;
  DBMS_OUTPUT.NEW_LINE();
END;

--------------------------------------------------------------------------------
------------------------------------PART B--------------------------------------
--------------------------------------------------------------------------------
BEGIN
   UPDATE iu_student
      SET facultyid = &facultyid
    WHERE majorid = &majorid;
    DBMS_OUTPUT.PUT_LINE('Num Rows updated? ' || SQL%ROWCOUNT);
    IF SQL%FOUND 
      THEN DBMS_OUTPUT.PUT_LINE('Any Rows updated? TRUE');
      ELSE DBMS_OUTPUT.PUT_LINE('Any Rows updated? FALSE');
    END IF;
    IF SQL%NOTFOUND
      THEN DBMS_OUTPUT.PUT_LINE('No Rows updated? TRUE');
      ELSE DBMS_OUTPUT.PUT_LINE('No Rows updated? FALSE');
    END IF;
END;

--------------------------------------------------------------------------------
------------------------------------PART C--------------------------------------
--------------------------------------------------------------------------------
DECLARE
  type lt_years IS VARRAY(4) of number;
  tests lt_years;
BEGIN
  tests := lt_years(1999, 2004, 1900, 2400);
  FOR x IN tests.first..tests.last LOOP
    IF MOD(tests(x), 4) = 0 THEN
      IF MOD(tests(x), 100) = 0 THEN
        IF MOD(tests(x), 400) = 0 THEN
          DBMS_OUTPUT.PUT_LINE(tests(x) || ' is a leap year');
        ELSE 
          DBMS_OUTPUT.PUT_LINE(tests(x) || ' is not a leap year');
        END IF;
      ELSE 
        DBMS_OUTPUT.PUT_LINE(tests(x) || ' is a leap year'); 
      END IF;            
    ELSE 
      DBMS_OUTPUT.PUT_LINE(tests(x) || ' is not a leap year');
    END IF;
  END LOOP;
END;



















