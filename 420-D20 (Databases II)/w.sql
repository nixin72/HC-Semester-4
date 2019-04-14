  FUNCTION areEqual (
    lv_val1_i in varchar2, 
    lv_val2_i in varchar2
  ) return boolean IS
  BEGIN
    return lv_val1_i = lv_val2_i;
  END areEqual;

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
      SELECT DISTINCT r.RUN_NUMBER, r.run_size
      FROM hvk_run r
      LEFT JOIN hvk_pet_reservation pr
        ON pr.RUN_RUN_NUMBER = r.RUN_NUMBER
        OR pr.run_run_number IS NULL
      LEFT JOIN hvk_reservation res
        ON res.RESERVATION_NUMBER = pr.RES_RESERVATION_NUMBER
      WHERE res.reservation_start_date >= pv_start_date_i
        AND res.reservation_end_date   <= pv_end_date_i;
  END list_available_runs_pp;
  
  --TEST PART A
  PROCEDURE test_list_available_runs (
    pv_num_passed_o OUT number,
    pv_num_run_o    OUT number
  ) AS
		lv_num_total number := 0;
		lv_num_pass  number := 0;
	
		lv_runNum_act number;
		lv_runNum_exp number;
		
		lv_runSize_act CHAR(1 byte);
		lv_runSize_exp CHAR(1 byte);
		
		test1_start_date date := to_date('05-Mar-17', 'dd-MM-yy');
		test1_end_date   date := to_date('25-Mar-17', 'dd-MM-yy');
		
		test2_start_date date := to_date('12-Sep-15', 'dd-MM-yy');
		test2_end_date   date := to_date('19-Sep-15', 'dd-MM-yy');
		
    lcur_res_starting Sys_refcursor;
		CURSOR lcur_expect IS 
		SELECT run_number, run_size FROM hvk_run
        MINUS
      SELECT DISTINCT r.RUN_NUMBER, r.run_size
      FROM hvk_run r
      LEFT JOIN hvk_pet_reservation pr
        ON pr.RUN_RUN_NUMBER = r.RUN_NUMBER
        OR pr.run_run_number IS NULL
      LEFT JOIN hvk_reservation res
        ON res.RESERVATION_NUMBER = pr.RES_RESERVATION_NUMBER
      WHERE res.reservation_start_date >= test1_start_date
        AND res.reservation_end_date   <= test1_end_date; 
  BEGIN
    list_reservations_starting_pp(pv_start_date_i => to_date('05-Mar-17', 'dd-MM-yy'), 
      pv_end_Date_i   => to_date('25-Mar-17', 'dd-MM-yy'),
      pv_cursor_o     => lcur_res_starting);
    
		LOOP
			FETCH lcur_res_starting into lv_runNum_act, lv_runSize_act;
			FETCH lcur_expect       into lv_runNum_exp, lv_runSize_exp;
			
			IF lv_runNum_act = lv_runNum_exp AND lv_runSize_act = lv_runSize_exp THEN
				lv_num_pass := lv_num_pass + 1;
			ELSE	
				DBMS_OUTPUT.PUT_LINE('---TEST CASE ' || lv_num_total || ' FAILED.');
				DBMS_OUTPUT.PUT_LINE('ACTUAL RUN NUMBER: ' || lv_runNum_act || ' EXPECTED NUMBER: ' || lv_runNum_exp);
				DBMS_OUTPUT.PUT_LINE('ACTUAL RUN NUMBER: ' || lv_runSize_act || ' EXPECTED NUMBER: ' || lv_runSize_exp);
			END IF;
			
			lv_num_total := lv_num_total + 1;
		END LOOP;
    
    pv_num_passed_o := lv_num_pass;
		pv_num_run_o    := lv_num_total;
  END;