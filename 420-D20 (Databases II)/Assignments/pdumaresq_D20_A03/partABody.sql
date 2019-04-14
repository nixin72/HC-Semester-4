create or replace PACKAGE BODY hvk_tables_list_package AS
--PART A
  PROCEDURE list_available_runs_pp (
    pv_start_date_i     hvk_reservation.reservation_start_date%TYPE,
    pv_end_date_i       hvk_reservation.reservation_end_date%TYPE,
    pv_cursor_o   OUT   SYS_REFCURSOR
  ) AS
  BEGIN
    OPEN pv_cursor_o FOR
      SELECT run_number, run_size FROM hvk_run
        MINUS
      SELECT DISTINCT run_number, run_size
      FROM hvk_run r, hvk_pet_reservation pr
      LEFT JOIN hvk_reservation res
        ON res.RESERVATION_NUMBER = pr.RES_RESERVATION_NUMBER
      WHERE res.reservation_start_date >= pv_start_date_i
        AND res.reservation_end_date   <= pv_end_date_i
        AND pr.RUN_RUN_NUMBER = r.RUN_NUMBER
        ORDER BY run_number;
  END list_available_runs_pp;
  
  --TEST PART A
  PROCEDURE test_list_available_runs (
    pv_num_passed_o OUT number,
    pv_num_run_o    OUT number
  ) AS
    lv_num_total     number := 0;
		lv_num_pass      number := 0;
	   
    type numRuns     IS VARRAY(3) OF NUMBER;
    type sizeRuns    IS VARRAY(3) OF CHAR(1 BYTE);
    type rowCount    IS VARRAY(3) OF NUMBER;
    type testDate    IS VARRAY(3) OF DATE;
    
    lv_runNums_exp   numRuns;
		lv_runSize_exp   sizeRuns;
		lv_numRow_exp    rowCount;
    lv_start_dates   testDate;
    lv_end_dates     testDate;
		
    lcur_test SYS_REFCURSOR;
    
    lv_runNum_act number;
    lv_runSize_act CHAR(1 byte);
    lv_numRow_act number;
  BEGIN
    DBMS_OUTPUT.PUT_LINE('------TEST LIST_AVAILABLE_RUNS-----');
    lv_runNums_exp   := numRuns(1, 1, null);
		lv_runSize_exp   := sizeRuns('R', 'R', null);
		lv_numRow_exp    := rowCount(10, 12, 0);
    lv_start_dates   := testDate(to_date('12-Sep-15', 'dd-MM-yy'), to_date('10-Mar-17', 'dd-MM-yy'), to_date('01-Jan-14', 'dd-MM-yy'));
    lv_end_dates     := testDate(to_date('19-Sep-15', 'dd-MM-yy'), to_date('25-Mar-17', 'dd-MM-yy'), to_date('01-Jan-18', 'dd-MM-yy'));
    
    --Make this change so that my test are accurate. Changes back after.
    UPDATE hvk_pet_reservation 
      SET run_run_number = 22
      WHERE pet_res_number = 200;
      commit;
    
    FOR x in 1..lv_runNums_exp.count LOOP
      lv_runNum_act := null;
      lv_runSize_act := null;
      lv_numRow_act := 0;
      
      list_available_runs_pp(lv_start_dates(x), lv_end_dates(x), lcur_test);
      
      FETCH lcur_test into lv_runNum_act, lv_runSize_act;
      IF lcur_test%FOUND THEN lv_numRow_act := lv_numRow_act + 1; END IF;
      
      IF NVL(lv_runNum_act, -1) = NVL(lv_runNums_exp(x), -1) 
        AND NVL(lv_runSize_act, 'Z') = NVL(lv_runSize_exp(x), 'Z') THEN
        lv_num_pass := lv_num_pass + 1;
        DBMS_OUTPUT.PUT_LINE('Test ' || ((x*2)-1) || ' passed.');
      ELSE
        DBMS_OUTPUT.PUT_LINE('---TEST CASE ' || ((x*2)-1) || ' FAILED. --');
        DBMS_OUTPUT.PUT_LINE('ACTUAL RUN NUMBER: ' || lv_runNum_act || ' EXPECTED NUMBER: ' || lv_runNums_exp(x));
        DBMS_OUTPUT.PUT_LINE('ACTUAL RUN SIZE: ' || lv_runSize_act || ' EXPECTED SIZE: ' || lv_runSize_exp(x));
      END IF;
      lv_num_total := lv_num_total + 1;
      
      LOOP
        FETCH lcur_test into lv_runNum_act, lv_runSize_act;
        IF lcur_test%FOUND THEN lv_numRow_act := lv_numRow_act + 1; END IF;        
        EXIT WHEN lcur_test%NOTFOUND;
      END LOOP;
      
      IF lv_numRow_act = lv_numRow_exp(x) THEN 
        lv_num_pass := lv_num_pass + 1;
        DBMS_OUTPUT.PUT_LINE('Test ' || (x*2) || ' passed.');
      ELSE
        DBMS_OUTPUT.PUT_LINE('---TEST CASE ' || (x*2) || ' FAILED. --');
        DBMS_OUTPUT.PUT_LINE('ACTUAL ROW COUNT: ' || lv_numRow_act || ' EXPECTED ROW COUNT: ' || lv_numRow_exp(x));
      END IF;
      lv_num_total := lv_num_total + 1;	
    END LOOP;

    --Change back to original data
    UPDATE hvk_pet_reservation 
      SET run_run_number = null
      WHERE pet_res_number = 200;
      commit;

    pv_num_passed_o := lv_num_pass;
		pv_num_run_o    := lv_num_total;
  END;
  
--PART B
  PROCEDURE list_reservations_starting_pp (
    pv_start_date_i     hvk_reservation.reservation_start_date%TYPE,
    pv_cursor_o   OUT   SYS_REFCURSOR
  ) AS
  BEGIN 
    OPEN pv_cursor_o FOR
      SELECT r.reservation_number, r.reservation_start_date, r.reservation_end_date
      FROM hvk_reservation r
      WHERE r.reservation_start_date >= pv_start_date_i
      ORDER BY r.reservation_number;
  END list_reservations_starting_pp;
  
  --TEST PART B
  PROCEDURE test_list_res_starting (
    pv_num_passed_o OUT number,
    pv_num_run_o    OUT number
  ) AS 
    lv_num_total     number := 0;
		lv_num_pass      number := 0;
	   
    type resNum      IS VARRAY(3) OF NUMBER;
    type resDate     IS VARRAY(3) OF DATE;
    
    lv_resNum_exp    resNum;
    lv_numRow_exp    resNum;
		lv_sDate_exp     resDate;
		lv_eDate_exp     resDate;
    lv_start_dates   resDate;
		
    lcur_test SYS_REFCURSOR;
    
    lv_resNum_act number;
    lv_sDate_act  DATE;
    lv_eDate_act  DATE;
    lv_numRow_act number;
    
    lv_date date := null;
  BEGIN
    DBMS_OUTPUT.PUT_LINE('');
    DBMS_OUTPUT.PUT_LINE('');
    DBMS_OUTPUT.PUT_LINE('------TEST LIST_RESERVATIONS_STARTING-----');
    lv_resNum_exp  := resNum(122, 100, null);
    lv_sDate_exp   := resDate(to_date('01-Jan-17', 'dd-MM-yy'), to_date('12-Sep-15', 'dd-MM-yy'), null);
    lv_eDate_exp   := resDate(to_date('05-Jan-17', 'dd-MM-yy'), to_date('19-Sep-15', 'dd-MM-yy'), null);
    lv_start_dates := resDate(to_date('01-Jan-17', 'dd-MM-yy'), to_date('01-Jan-14', 'dd-MM-yy'), to_date('01-Jan-18', 'dd-MM-yy'));
    lv_numRow_exp  := resNum(39, 65, 0);
    
    FOR x in 1..lv_resNum_exp.count LOOP
      lv_resNum_act := null;
      lv_sDate_act := null;
      lv_eDate_act := null;
      lv_numRow_act := 0;
    
      lv_numRow_act := 0;
      list_reservations_starting_pp(lv_start_dates(x), lcur_test);
      FETCH lcur_test into lv_resNum_act, lv_sDate_act, lv_eDate_act;
      IF lcur_test%FOUND THEN lv_numRow_act := lv_numRow_act + 1; END IF;
            
      IF nvl(lv_resNum_act, 0) = nvl(lv_resNum_exp(x), 0) 
        AND nvl(lv_sDate_act, to_date('01-01-01','dd-mm-yy')) = nvl(lv_sDate_exp(x), to_date('01-01-01','dd-mm-yy')) 
        AND nvl(lv_eDate_act, to_date('01-01-01','dd-mm-yy')) = nvl(lv_eDate_exp(x), to_date('01-01-01','dd-mm-yy')) 
        THEN 
        lv_num_pass := lv_num_pass + 1;
        DBMS_OUTPUT.PUT_LINE('Test ' || ((x*2)-1) || ' passed.');
      ELSE
        DBMS_OUTPUT.PUT_LINE('');
        DBMS_OUTPUT.PUT_LINE('---TEST CASE ' || ((x*2)-1) || ' FAILED. --');
        DBMS_OUTPUT.PUT_LINE('ACTUAL RUN NUMBER: ' || lv_resNum_act || ' EXPECTED NUMBER: ' || lv_resNum_exp(x));
        DBMS_OUTPUT.PUT_LINE('ACTUAL RUN SIZE: ' || lv_sDate_act || ' EXPECTED NUMBER: ' || lv_sDate_exp(x));
        DBMS_OUTPUT.PUT_LINE('ACTUAL RUN SIZE: ' || lv_eDate_act || ' EXPECTED NUMBER: ' || lv_eDate_exp(x));
      END IF;
      lv_num_total := lv_num_total + 1;
      
      LOOP
        FETCH lcur_test into lv_resNum_act, lv_sDate_act, lv_eDate_act;
        IF lcur_test%FOUND THEN lv_numRow_act := lv_numRow_act + 1; END IF;
        EXIT WHEN lcur_test%NOTFOUND;
      END LOOP;
      
      IF lv_numRow_act = lv_numRow_exp(x) THEN 
        lv_num_pass := lv_num_pass + 1;
        DBMS_OUTPUT.PUT_LINE('Test ' || (x*2) || ' passed.');
      ELSE
        DBMS_OUTPUT.PUT_LINE('');
        DBMS_OUTPUT.PUT_LINE('---TEST CASE ' || (x*2) || ' FAILED. --');
        DBMS_OUTPUT.PUT_LINE('ACTUAL ROW COUNT: ' || lv_numRow_act || ' EXPECTED ROW COUNT: ' || lv_numRow_exp(x));
      END IF;
      lv_num_total := lv_num_total + 1;	
    END LOOP;

    pv_num_passed_o := lv_num_pass;
		pv_num_run_o    := lv_num_total;
  END;
  
--PART C  
  PROCEDURE list_reservations_ending_pp (
    pv_end_date_i       hvk_reservation.reservation_end_date%TYPE,
    pv_cursor_o   OUT   SYS_REFCURSOR
  ) AS
  BEGIN
    OPEN pv_cursor_o FOR
      SELECT r.reservation_number, r.reservation_start_date, r.reservation_end_date
      FROM hvk_reservation r
      WHERE r.reservation_end_date >= pv_end_date_i
      ORDER BY r.reservation_number;
  END list_reservations_ending_pp;
    
  --TEST PART C
  PROCEDURE test_list_res_ending (
    pv_num_passed_o OUT number,
    pv_num_run_o    OUT number
  ) AS
    lv_num_total     number := 0;
		lv_num_pass      number := 0;
	   
    type resNum      IS VARRAY(3) OF NUMBER;
    type resDate     IS VARRAY(3) OF DATE;
    
    lv_resNum_exp    resNum;
    lv_numRow_exp    resNum;
		lv_sDate_exp     resDate;
		lv_eDate_exp     resDate;
    lv_end_dates     resDate;
		
    lcur_test SYS_REFCURSOR;
    
    lv_resNum_act number;
    lv_sDate_act  DATE;
    lv_eDate_act  DATE;
    lv_numRow_act number;
    
    lv_date date := null;
  BEGIN
    DBMS_OUTPUT.PUT_LINE('');
    DBMS_OUTPUT.PUT_LINE('');
    DBMS_OUTPUT.PUT_LINE('------TEST LIST_RESERVATIONS_ENDING-----');
    lv_resNum_exp  := resNum(122, 100, null);
    lv_sDate_exp   := resDate(to_date('01-Jan-17', 'dd-MM-yy'), to_date('12-Sep-15', 'dd-MM-yy'), null);
    lv_eDate_exp   := resDate(to_date('05-Jan-17', 'dd-MM-yy'), to_date('19-Sep-15', 'dd-MM-yy'), null);
    lv_end_dates   := resDate(to_date('01-Jan-17', 'dd-MM-yy'), to_date('01-Jan-14', 'dd-MM-yy'), to_date('01-Jan-18', 'dd-MM-yy'));
    lv_numRow_exp  := resNum(48, 65, 0);
    
    FOR x in 1..lv_resNum_exp.count LOOP
      lv_resNum_act := null;
      lv_sDate_act := null;
      lv_eDate_act := null;
      lv_numRow_act := 0;
      
      list_reservations_ending_pp(lv_end_dates(x), lcur_test);
      FETCH lcur_test into lv_resNum_act, lv_sDate_act, lv_eDate_act;
      IF lcur_test%FOUND THEN lv_numRow_act := lv_numRow_act + 1; END IF;
            
      IF nvl(lv_resNum_act, 0) = nvl(lv_resNum_exp(x), 0) 
        AND nvl(lv_sDate_act, to_date('01-01-01','dd-mm-yy')) = nvl(lv_sDate_exp(x), to_date('01-01-01','dd-mm-yy')) 
        AND nvl(lv_eDate_act, to_date('01-01-01','dd-mm-yy')) = nvl(lv_eDate_exp(x), to_date('01-01-01','dd-mm-yy')) 
        THEN
        lv_num_pass := lv_num_pass + 1;
        DBMS_OUTPUT.PUT_LINE('Test ' || ((x*2)-1) || ' passed.');
      ELSE
        DBMS_OUTPUT.PUT_LINE('');
        DBMS_OUTPUT.PUT_LINE('---TEST CASE ' || ((x*2)-1) || ' FAILED. --');
        DBMS_OUTPUT.PUT_LINE('ACTUAL RUN NUMBER: ' || lv_resNum_act || ' EXPECTED NUMBER: ' || lv_resNum_exp(x));
        DBMS_OUTPUT.PUT_LINE('ACTUAL RUN SIZE: ' || lv_sDate_act || ' EXPECTED NUMBER: ' || lv_sDate_exp(x));
        DBMS_OUTPUT.PUT_LINE('ACTUAL RUN SIZE: ' || lv_eDate_act || ' EXPECTED NUMBER: ' || lv_eDate_exp(x));
      END IF;
      lv_num_total := lv_num_total + 1;
      
      LOOP
        FETCH lcur_test into lv_resNum_act, lv_sDate_act, lv_eDate_act;
        IF lcur_test%FOUND THEN lv_numRow_act := lv_numRow_act + 1; END IF;
        EXIT WHEN lcur_test%NOTFOUND;
      END LOOP;
      
      IF lv_numRow_act = lv_numRow_exp(x) THEN 
        lv_num_pass := lv_num_pass + 1;
        DBMS_OUTPUT.PUT_LINE('Test ' || (x*2) || ' passed.');
      ELSE
        DBMS_OUTPUT.PUT_LINE('');
        DBMS_OUTPUT.PUT_LINE('---TEST CASE ' || (x*2) || ' FAILED. --');
        DBMS_OUTPUT.PUT_LINE('ACTUAL ROW COUNT: ' || lv_numRow_act || ' EXPECTED ROW COUNT: ' || lv_numRow_exp(x));
      END IF;
      lv_num_total := lv_num_total + 1;	
    END LOOP;

    pv_num_passed_o := lv_num_pass;
		pv_num_run_o    := lv_num_total;
  END;
  
--PART D
  PROCEDURE list_active_reservations_pp (
    pv_owner_number_i   hvk_owner.owner_number%TYPE DEFAULT null,
    pv_date_i           hvk_reservation.reservation_start_date%TYPE DEFAULT SYSDATE,
    pv_cursor_o   OUT   SYS_REFCURSOR
  ) AS
  BEGIN
    OPEN pv_cursor_o FOR
      SELECT r.reservation_number, o.owner_first_name, o.owner_last_name,
        p.pet_number, p.pet_name, pr.run_run_number,
        r.reservation_start_date, r.reservation_end_date
      FROM hvk_owner o, hvk_pet p, hvk_pet_reservation pr, hvk_reservation r
      WHERE r.reservation_start_date <= pv_date_i
        AND r.reservation_end_Date   >= pv_date_i
        AND (pv_owner_number_i       is null 
         OR pv_owner_number_i         = o.owner_number)
        AND o.owner_number            = p.own_owner_number
        AND p.pet_number              = pr.pet_pet_number
        AND pr.res_reservation_number = r.reservation_number
        ORDER BY r.reservation_number;
  END list_active_reservations_pp;
  
  --TEST PART D
  PROCEDURE test_list_active_res (
    pv_num_passed_o OUT number,
    pv_num_run_o    OUT number
  ) AS
    lv_num_total     number := 0;
		lv_num_pass      number := 0;
	   
    type pk          IS VARRAY(4) OF NUMBER;
    type names       IS VARRAY(4) OF VARCHAR2(25);
    type resDate     IS VARRAY(4) OF DATE;
    
    --Expected Data
    lv_resNum_exp    pk;
    lv_fName_exp     names;
    lv_lName_exp     names;
    lv_petNum_exp    pk;
    lv_pName_exp     names;
    lv_runNum_exp    pk;    
		lv_sDate_exp     resDate;
		lv_eDate_exp     resDate;
    lv_numRows_exp   pk;
    --Passed data
    lv_ownNums       pk;
    lv_sDates        resDate;
    
		
    lcur_test SYS_REFCURSOR;
    
    lv_resNum_act number;
    lv_fName_act  VARCHAR2(25);
    lv_lName_act  VARCHAR2(25);
    lv_petNum_act number;
    lv_pName_act  VARCHAR2(25);
    lv_runNum_act number;
    lv_sDate_act  DATE;
    lv_eDate_act  DATE;
    lv_numRow_act number;
    
    lv_date date := null;
  BEGIN
    DBMS_OUTPUT.PUT_LINE('');
    DBMS_OUTPUT.PUT_LINE('');
    DBMS_OUTPUT.PUT_LINE('------TEST LIST_ACTIVE_RESERVATIONS-----');
    --MAKE UP DATA
    lv_resNum_exp  := pk(630, null, 630, null);
    lv_fName_exp   := names('Barb B.', null, 'Barb B.', null);
    lv_lName_exp   := names('Que', null, 'Que', null);
    lv_petNum_exp  := pk(33, null, 33, null);
    lv_pName_exp   := names('Willie', null, 'Willie', null);
    lv_runNum_exp  := pk(13, null, 13, null);
    lv_sDate_exp   := resDate(to_date('05-Mar-17','dd-MM-yy'), null, to_date('05-Mar-17','dd-MM-yy'), null);
    lv_eDate_exp   := resDate(to_date('13-Mar-17','dd-MM-yy'), null, to_date('13-Mar-17','dd-MM-yy'), null);
    lv_numRows_exp := pk(1, 0, 1, 0);
        
    lv_ownNums     := pk(18, 18, null, null);
    lv_sDates      := resDate(to_date('10-Mar-17','dd-MM-yy'), null, to_date('10-Mar-17','dd-MM-yy'), null);
    
    FOR x in 1..lv_resNum_exp.count LOOP
      lv_resNum_act := null;
      lv_fName_act  := null;
      lv_lName_act  := null;
      lv_petNum_act := null;
      lv_pName_act  := null;
      lv_runNum_act := null;
      lv_sDate_act  := null;
      lv_eDate_act  := null;      
      lv_numRow_act := 0;
      
      list_active_reservations_pp(lv_ownNums(x), lv_sDates(x), lcur_test);
      FETCH lcur_test into lv_resNum_act, lv_fName_act, lv_lName_act, lv_petNum_act, lv_pName_act, lv_runNum_act, lv_sDate_act, lv_eDate_act;
      IF lcur_test%FOUND THEN lv_numRow_act := lv_numRow_act + 1; END IF;
            
      IF    nvl(lv_resNum_act, -1)  = nvl(lv_resNum_exp(x), -1) AND nvl(lv_fName_act, '~') = nvl(lv_fName_exp(x), '~') 
        AND nvl(lv_lName_act, '~')  = nvl(lv_lName_exp(x), '~') AND nvl(lv_petNum_act, -1) = nvl(lv_petNum_exp(x), -1)
        AND nvl(lv_pName_act, '~')  = nvl(lv_pName_exp(x), '~') AND nvl(lv_runNum_act, -1) = nvl(lv_runNum_exp(x), -1)
        AND nvl(lv_sDate_act, to_date('01-01-01','dd-mm-yy'))     = nvl(lv_sDate_exp(x), to_date('01-01-01','dd-mm-yy'))  
        AND nvl(lv_eDate_act, to_date('01-01-01','dd-mm-yy'))     = nvl(lv_eDate_exp(x), to_date('01-01-01','dd-mm-yy')) 
        THEN 
        lv_num_pass := lv_num_pass + 1;
        DBMS_OUTPUT.PUT_LINE('Test ' || ((x*2)-1) || ' passed.');
      ELSE
        DBMS_OUTPUT.PUT_LINE('');
        DBMS_OUTPUT.PUT_LINE('---TEST CASE ' || ((x*2)-1) || ' FAILED. --');
        DBMS_OUTPUT.PUT_LINE('ACTUAL RUN NUMBER: ' || lv_resNum_act || ' EXPECTED NUMBER: ' || lv_resNum_exp(x));
        DBMS_OUTPUT.PUT_LINE('ACTUAL RUN SIZE: ' || lv_sDate_act || ' EXPECTED NUMBER: ' || lv_sDate_exp(x));
        DBMS_OUTPUT.PUT_LINE('ACTUAL RUN SIZE: ' || lv_eDate_act || ' EXPECTED NUMBER: ' || lv_eDate_exp(x));
      END IF;
      lv_num_total := lv_num_total + 1;
      
      LOOP
        FETCH lcur_test into lv_resNum_act, lv_fName_act, lv_lName_act, lv_petNum_act, lv_pName_act, lv_runNum_act, lv_sDate_act, lv_eDate_act;
        IF lcur_test%FOUND THEN lv_numRow_act := lv_numRow_act + 1; END IF;        
        EXIT WHEN lcur_test%NOTFOUND;
      END LOOP;
      
      IF lv_numRow_act = lv_numRows_exp(x) THEN 
        lv_num_pass := lv_num_pass + 1;
        DBMS_OUTPUT.PUT_LINE('Test ' || (x*2) || ' passed.');
      ELSE
        DBMS_OUTPUT.PUT_LINE('');
        DBMS_OUTPUT.PUT_LINE('---TEST CASE ' || (x*2) || ' FAILED. --');
        DBMS_OUTPUT.PUT_LINE('ACTUAL ROW COUNT: ' || lv_numRow_act || ' EXPECTED ROW COUNT: ' || lv_numRows_exp(x));
      END IF;
      lv_num_total := lv_num_total + 1;	
    END LOOP;

    pv_num_passed_o := lv_num_pass;
		pv_num_run_o    := lv_num_total;
  END;
  
--PART E  
  PROCEDURE list_active_reservations_pp (
    pv_cursor_o   OUT   SYS_REFCURSOR,
    pv_owner_number_i   hvk_owner.owner_number%TYPE DEFAULT null,
    pv_start_date_i     hvk_reservation.reservation_start_date%TYPE DEFAULT SYSDATE,
    pv_end_date_i       hvk_reservation.reservation_end_date%TYPE DEFAULT SYSDATE    
  ) AS
    lv_sDate DATE;
    lv_eDate DATE;
  BEGIN
    IF pv_start_date_i IS NULL THEN 
      lv_sDate := sysdate;
    ELSE 
      lv_sDate := pv_start_date_i;
    END IF;
    
    IF pv_end_date_i IS NULL THEN 
      lv_eDate := sysdate;
    ELSE 
      lv_eDate := pv_end_date_i;
    END IF;
   
   OPEN pv_cursor_o FOR
      SELECT r.reservation_number, o.owner_first_name, o.owner_last_name,
        p.pet_number, p.pet_name, pr.run_run_number,
        r.reservation_start_date, r.reservation_end_date
      FROM hvk_owner o, hvk_pet p, hvk_pet_reservation pr, hvk_reservation r
      WHERE r.reservation_start_date >= lv_sDate
        AND r.reservation_end_date   <= lv_eDate
        AND (pv_owner_number_i       is null 
         OR pv_owner_number_i         = o.owner_number)
        AND o.owner_number            = p.own_owner_number
        AND p.pet_number              = pr.pet_pet_number
        AND pr.res_reservation_number = r.reservation_number
        ORDER BY r.reservation_number;
  END list_active_reservations_pp;
  
  --TEST PART E
  PROCEDURE test_list_active_res_2 (
    pv_num_passed_o OUT number,
    pv_num_run_o    OUT number
  ) AS
    lv_num_total     number := 0;
		lv_num_pass      number := 0;
	   
    type pk          IS VARRAY(8) OF NUMBER;
    type names       IS VARRAY(8) OF VARCHAR2(25);
    type resDate     IS VARRAY(8) OF DATE;
    
    --Expected Data
    lv_resNum_exp    pk;
    lv_fName_exp     names;
    lv_lName_exp     names;
    lv_petNum_exp    pk;
    lv_pName_exp     names;
    lv_runNum_exp    pk;    
		lv_sDate_exp     resDate;
		lv_eDate_exp     resDate;
    lv_numRows_exp   pk;
    --Passed data
    lv_ownNums       pk;
    lv_sDates        resDate;
    lv_eDates        resDate;
		
    lcur_test SYS_REFCURSOR;
    
    lv_resNum_act number;
    lv_fName_act  VARCHAR2(25);
    lv_lName_act  VARCHAR2(25);
    lv_petNum_act number;
    lv_pName_act  VARCHAR2(25);
    lv_runNum_act number;
    lv_sDate_act  DATE;
    lv_eDate_act  DATE;
    lv_numRow_act number;
    
    lv_date date := null;
  BEGIN
    DBMS_OUTPUT.PUT_LINE('');
    DBMS_OUTPUT.PUT_LINE('');
    DBMS_OUTPUT.PUT_LINE('------TEST LIST_ACTIVE_RESERVATIONS-----');
    lv_resNum_exp  := pk(630, 630, null, null, 625, 625, 721, null);
    lv_fName_exp   := names('Barb B.', 'Barb B.', null, null, 'Ella', 'Ella', 'Mike', null);
    lv_lName_exp   := names('Que', 'Que', null, null, 'Mentary', 'Mentary', 'O''Phone', null);
    lv_petNum_exp  := pk(33, 33, null, null, 20, 20, 3, null);
    lv_pName_exp   := names('Willie', 'Willie', null, null, 'Poppy', 'Poppy', 'Jasper', null);
    lv_runNum_exp  := pk(13, 13, null, null, null, null, 27, null);
    lv_sDate_exp   := resDate(to_date('05-Mar-17', 'dd-MM-yy'), to_date('05-Mar-17', 'dd-MM-yy'), 
      null, null, to_date('15-Mar-17','dd-MM-yy'), to_date('15-Mar-17','dd-MM-yy'), to_date('05-Apr-17','dd-MM-yy'), null);
    lv_eDate_exp   := resDate(to_date('13-Mar-17', 'dd-MM-yy'), to_date('13-Mar-17', 'dd-MM-yy'), 
      null, null, to_date('20-Mar-17','dd-MM-yy'), to_date('20-Mar-17','dd-MM-yy'), to_date('09-Apr-17','dd-MM-yy'), null);
    lv_numRows_exp := pk(2, 2, 0, 0, 6, 5, 1, 0);
        
    lv_ownNums     := pk(18, 18, 18, 18, null, null, null, null);
    lv_sDates := resDate(to_date('05-Mar-17','dd-MM-yy'), to_date('05-Mar-17','dd-MM-yy'), NULL, NULL, to_date('05-Mar-17','dd-MM-yy'), to_date('05-Mar-17','dd-MM-yy'), NULL, NULL);
    lv_eDates := resDate(to_date('15-Apr-17','dd-MM-yy'), NULL, to_date('15-Apr-17','dd-MM-yy'), NULL, to_date('15-Apr-17','dd-MM-yy'), NULL, to_date('15-Apr-17','dd-MM-yy'), NULL);
    
    FOR x in 1..lv_resNum_exp.count LOOP
      lv_resNum_act := null;
      lv_fName_act  := null;
      lv_lName_act  := null;
      lv_petNum_act := null;
      lv_pName_act  := null;
      lv_runNum_act := null;
      lv_sDate_act  := null;
      lv_eDate_act  := null;      
      lv_numRow_act := 0;

      list_active_reservations_pp(lcur_test, lv_ownNums(x), lv_sDates(x), lv_eDates(x));
      FETCH lcur_test into lv_resNum_act, lv_fName_act, lv_lName_act, lv_petNum_act, lv_pName_act, lv_runNum_act, lv_sDate_act, lv_eDate_act;
      IF lcur_test%FOUND THEN lv_numRow_act := lv_numRow_act + 1; END IF;
            
      IF    nvl(lv_resNum_act, -1)  = nvl(lv_resNum_exp(x), -1) AND nvl(lv_fName_act, '~') = nvl(lv_fName_exp(x), '~') 
        AND nvl(lv_lName_act, '~')  = nvl(lv_lName_exp(x), '~') AND nvl(lv_petNum_act, -1) = nvl(lv_petNum_exp(x), -1)
        AND nvl(lv_pName_act, '~')  = nvl(lv_pName_exp(x), '~') AND nvl(lv_runNum_act, -1) = nvl(lv_runNum_exp(x), -1)
        AND nvl(lv_sDate_act, to_date('01-01-01','dd-mm-yy'))     = nvl(lv_sDate_exp(x), to_date('01-01-01','dd-mm-yy'))  
        AND nvl(lv_eDate_act, to_date('01-01-01','dd-mm-yy'))     = nvl(lv_eDate_exp(x), to_date('01-01-01','dd-mm-yy')) 
        THEN 
          lv_num_pass := lv_num_pass + 1;
          DBMS_OUTPUT.PUT_LINE('Test ' || ((x*2)-1) || ' passed.');
      ELSE
        DBMS_OUTPUT.PUT_LINE('');
        DBMS_OUTPUT.PUT_LINE('---TEST CASE ' || ((x*2)-1) || ' FAILED. --');
        DBMS_OUTPUT.PUT_LINE('ACTUAL RUN NUMBER: ' || lv_resNum_act || ' EXPECTED NUMBER: ' || lv_resNum_exp(x));
        DBMS_OUTPUT.PUT_LINE('ACTUAL RUN SIZE: ' || lv_fName_act || ' EXPECTED NUMBER: ' || lv_fName_exp(x));
        DBMS_OUTPUT.PUT_LINE('ACTUAL RUN SIZE: ' || lv_lName_act || ' EXPECTED NUMBER: ' || lv_lName_exp(x));
        DBMS_OUTPUT.PUT_LINE('ACTUAL RUN SIZE: ' || lv_petNum_act || ' EXPECTED NUMBER: ' || lv_petNum_exp(x));
        DBMS_OUTPUT.PUT_LINE('ACTUAL RUN SIZE: ' || lv_pName_act || ' EXPECTED NUMBER: ' || lv_pName_exp(x));
        DBMS_OUTPUT.PUT_LINE('ACTUAL RUN SIZE: ' || lv_runNum_act || ' EXPECTED NUMBER: ' || lv_runNum_exp(x));
        DBMS_OUTPUT.PUT_LINE('ACTUAL RUN SIZE: ' || lv_sDate_act || ' EXPECTED NUMBER: ' || lv_sDate_exp(x));
        DBMS_OUTPUT.PUT_LINE('ACTUAL RUN SIZE: ' || lv_eDate_act || ' EXPECTED NUMBER: ' || lv_eDate_exp(x));
      END IF;
      lv_num_total := lv_num_total + 1;
      
      LOOP
        FETCH lcur_test into lv_resNum_act, lv_fName_act, lv_lName_act, lv_petNum_act, lv_pName_act, lv_runNum_act, lv_sDate_act, lv_eDate_act;
        IF lcur_test%FOUND THEN lv_numRow_act := lv_numRow_act + 1; END IF;        
        EXIT WHEN lcur_test%NOTFOUND;
      END LOOP;
      
      IF lv_numRow_act  = lv_numRows_exp(x) THEN 
        lv_num_pass    := lv_num_pass + 1;
        DBMS_OUTPUT.PUT_LINE('Test ' || (x*2) || ' passed.');
      ELSE
        DBMS_OUTPUT.PUT_LINE('');
        DBMS_OUTPUT.PUT_LINE('---TEST CASE ' || (x*2) || ' FAILED. --');
        DBMS_OUTPUT.PUT_LINE('ACTUAL ROW COUNT: ' || lv_numRow_act || ' EXPECTED ROW COUNT: ' || lv_numRows_exp(x));
      END IF;
      lv_num_total := lv_num_total + 1;	
    END LOOP;

    pv_num_passed_o := lv_num_pass;
		pv_num_run_o    := lv_num_total;
  END;
  
--PART F  
  PROCEDURE list_check_vaccinations_pp (
    pv_pet_number_i     hvk_pet.pet_number%TYPE,
    pv_res_number_i     hvk_reservation.reservation_number%TYPE,
    pv_cursor_o   OUT   SYS_REFCURSOR
  ) AS 
  BEGIN
    OPEN pv_cursor_o FOR
      SELECT v.vaccination_name 
        FROM hvk_pet_vaccination pv, hvk_vaccination v, hvk_reservation r
          WHERE pv.pet_pet_number       = pv_pet_number_i
            AND r.reservation_number    = pv_res_number_i
            AND r.reservation_end_date >= pv.vaccination_expiry_date
            AND v.vaccination_number    = pv.vacc_vaccination_number
        UNION (
          SELECT vaccination_name FROM hvk_vaccination
            MINUS
            SELECT v.vaccination_name
            FROM hvk_pet_vaccination pv, hvk_vaccination v
            WHERE pv.pet_pet_number    = pv_pet_number_i
              AND v.vaccination_number = pv.vacc_vaccination_number
        );
  END list_check_vaccinations_pp;
  
  --TEST PART F
  PROCEDURE test_list_check_vacc (
    pv_num_passed_o OUT number,
    pv_num_run_o    OUT number
  ) AS
    lv_num_total     number := 0;
		lv_num_pass      number := 0;
	   
    type numm        IS VARRAY(5) OF NUMBER;
    type vacc        IS VARRAY(5) OF VARCHAR2(25);
    
    --Expected Data
    lv_vacc_exp      vacc;
    lv_numRows_exp   numm;
    --Passed data
    lv_petNums       numm;
    lv_resNums       numm;
		
    lcur_test        SYS_REFCURSOR;
    
    lv_vacc_act      VARCHAR2(25);
    lv_numRow_act    number;
  BEGIN
    DBMS_OUTPUT.PUT_LINE('');
    DBMS_OUTPUT.PUT_LINE('');
    DBMS_OUTPUT.PUT_LINE('------TEST LIST_CHECK_VACCINATIONS-----');
    --MAKE UP DATA
    lv_vacc_exp    := vacc(null, 'Bordetella', 'Hepatitis');
    lv_numRows_exp := numm(0, 4, 2);
        
    lv_petNums     := numm(1, 6, 7);   
    lv_resNums     := numm(100, 106, 631);
    
    FOR x in 1..lv_vacc_exp.count LOOP
      lv_vacc_act := null;
      lv_numRow_act := 0;
      list_check_vaccinations_pp(lv_petNums(x), lv_resNums(x), lcur_test);
      FETCH lcur_test into lv_vacc_act;
      IF lcur_test%FOUND THEN lv_numRow_act := lv_numRow_act + 1; END IF;
            
      IF nvl(lv_vacc_act, '~') = nvl(lv_vacc_exp(x), '~') THEN
        lv_num_pass := lv_num_pass + 1;
        DBMS_OUTPUT.PUT_LINE('Test ' || ((x*2)-1) || ' passed.');
      ELSE
        DBMS_OUTPUT.PUT_LINE('');
        DBMS_OUTPUT.PUT_LINE('---TEST CASE ' || ((x*2)-1) || ' FAILED. --');
        DBMS_OUTPUT.PUT_LINE('ACTUAL VACCINATION: ' || lv_vacc_act || ' EXPECTED VACCINATION: ' || lv_vacc_exp(x));
      END IF;
      lv_num_total := lv_num_total + 1;
      
      LOOP
        FETCH lcur_test into lv_vacc_act;
        IF lcur_test%FOUND THEN lv_numRow_act := lv_numRow_act + 1; END IF;        
        EXIT WHEN lcur_test%NOTFOUND;
      END LOOP;
      
      IF lv_numRow_act  = lv_numRows_exp(x) THEN 
        lv_num_pass    := lv_num_pass + 1;
        DBMS_OUTPUT.PUT_LINE('Test ' || (x*2) || ' passed.');
      ELSE
        DBMS_OUTPUT.PUT_LINE('');
        DBMS_OUTPUT.PUT_LINE('---TEST CASE ' || (x*2) || ' FAILED. --');
        DBMS_OUTPUT.PUT_LINE('ACTUAL ROW COUNT: ' || lv_numRow_act || ' EXPECTED ROW COUNT: ' || lv_numRows_exp(x));
      END IF;
      lv_num_total := lv_num_total + 1;	
    END LOOP;

    pv_num_passed_o := lv_num_pass;
		pv_num_run_o    := lv_num_total;
  END;

  --Test all procedures  
  PROCEDURE test_package_pp AS
    lv_number_passed number := 0;
    lv_total number := 0;
    lv_temp_passed number;
    lv_temp_total number;
  BEGIN    
      test_list_available_runs(lv_temp_passed, lv_temp_total);
      lv_number_passed := lv_number_passed + lv_temp_passed;
      lv_total := lv_total + lv_temp_total;
      
      test_list_res_starting(lv_temp_passed, lv_temp_total);
      lv_number_passed := lv_number_passed + lv_temp_passed;
      lv_total := lv_total + lv_temp_total;
      
      test_list_res_ending(lv_temp_passed, lv_temp_total);
      lv_number_passed := lv_number_passed + lv_temp_passed;
      lv_total := lv_total + lv_temp_total;
      
      test_list_active_res(lv_temp_passed, lv_temp_total);
      lv_number_passed := lv_number_passed + lv_temp_passed;
      lv_total := lv_total + lv_temp_total;
      
      test_list_active_res_2(lv_temp_passed, lv_temp_total);
      lv_number_passed := lv_number_passed + lv_temp_passed;
      lv_total := lv_total + lv_temp_total;
      
      test_list_check_vacc(lv_temp_passed, lv_temp_total);
      lv_number_passed := lv_number_passed + lv_temp_passed;
      lv_total := lv_total + lv_temp_total;
      
      
      DBMS_OUTPUT.PUT_LINE('Tests run: ' || lv_total);
      DBMS_OUTPUT.PUT_LINE('Tests passed: ' || lv_number_passed || '/' || lv_total 
        || ' ' || (lv_number_passed/lv_total * 100));
      DBMS_OUTPUT.PUT_LINE('Tests failed: ' || (lv_total-lv_number_passed) || '/' || lv_total 
        || ' ' || (100-(lv_number_passed/lv_total * 100)));
  END test_package_pp;
  
END hvk_tables_list_package;