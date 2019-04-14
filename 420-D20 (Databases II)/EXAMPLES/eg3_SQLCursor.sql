SET SERVEROUTPUT ON;
declare 
  lv_count number(7) := 0;
  lv_salary_limit number(9) :=1000000;
Begin
  select count(*) into lv_count
  from NN_EMPLOYEE 
  where salary > lv_salary_limit;

  DBMS_OUTPUT.PUT_LINE ('There are ' || lv_count ||
      ' employees with a salary exceeding '|| to_char(lv_salary_limit, '$9,999,999'));

  IF SQL%FOUND 
    THEN DBMS_OUTPUT.put_line ('    FOUND: true');
    ELSE DBMS_OUTPUT.put_line ('    FOUND: false');
  END IF;

  IF SQL%NOTFOUND 
    THEN DBMS_OUTPUT.put_line ('    NOTFOUND: true');
    ELSE DBMS_OUTPUT.put_line ('    NOTFOUND: false');
  END IF;
   
  DBMS_OUTPUT.PUT_LINE(' Rowcount: ' || SQL%rowcount);
end;



DECLARE
  lv_csid number := 4600;
  CURSOR lcur_cursor
    IS select courseid, section, maxcount 
      from iu_crssection cs
      where cs.termid = 'WN15';
BEGIN
  INSERT INTO iu_term (termid, termdesc, startdate, enddate)
    VALUES ('WN17', 'Winter 2017', to_date('01-19-2017', 'MM-DD-YYYY'), to_date('06-01-2017', 'MM-DD-YYYY'));
    
  FOR lrec_terms in lcur_cursor LOOP
    INSERT INTO iu_term (csid, courseid, section, termid, MAXCOUNT) 
    VALUES (lv_csid, lrec_terms.courseid, lrec_terms.section, 'WN17', lrec_terms.maxcount);
    
    lv_csid := lv_csid + 1;
  END LOOP;
END;


