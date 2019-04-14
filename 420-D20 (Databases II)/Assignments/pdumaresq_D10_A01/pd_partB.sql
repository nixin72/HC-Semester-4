--------------------------------------------------------------------------------
-----------------------------------PART B---------------------------------------
--------------------------------------------------------------------------------
SET DEFINE ON;
SET SERVEROUTPUT ON;
DECLARE
  lv_number      hvk_service.service_number%TYPE;
  lv_desc        hvk_service.service_description%TYPE     := '&Service_Description';
  lv_found       NUMBER;
  lv_rate_num    hvk_daily_rate.daily_rate_number%TYPE;
  lv_same_rate   BOOLEAN;
  lv_basic_rate  hvk_daily_rate.daily_rate%TYPE;
  lv_increase    NUMBER;
  lv_size        hvk_daily_rate.daily_rate_dog_size%TYPE;
  
  lv_ser_seq     number;
  lv_dr_seq      number;
BEGIN
  SELECT hvk_service_seq.NEXTVAL INTO lv_ser_seq FROM DUAL;
  SELECT hvk_daily_rate_seq.NEXTVAL INTO lv_dr_seq  FROM DUAL;

  lv_desc := UPPER(SUBSTR(lv_desc, 0, 1)) || LOWER(SUBSTR(lv_desc, 2));
  SELECT COUNT(*) INTO lv_FOUND
    FROM hvk_service
    WHERE service_description = lv_desc;
  IF lv_found = 0 THEN
    lv_same_rate            := 'N' = UPPER('&Same_rate_for_all_dog_sizes?');
    lv_basic_rate           := &Basic_daily_rate;
    lv_increase             := &Increase_between_dog_sizes;
    lv_increase             := (lv_increase/100)+1;
    
    
    
    INSERT INTO hvk_service (
        service_number, service_description
      ) VALUES (
        hvk_service_seq.CURRVAL, lv_desc
      );
    IF lv_same_rate THEN
      INSERT INTO hvk_daily_rate (
          daily_rate_number,   daily_rate,
          daily_rate_dog_size, serv_service_number
        ) VALUES (
          hvk_daily_rate_seq.CURRVAL, lv_basic_rate,
          NULL, hvk_service_seq.CURRVAL
        );
    ELSE
      FOR lv_loop in 0..2 LOOP
        CASE lv_loop
        WHEN 0 THEN
          INSERT INTO hvk_daily_rate (
              DAILY_RATE_NUMBER,   DAILY_RATE,
              DAILY_RATE_DOG_SIZE, SERV_SERVICE_NUMBER
            ) VALUES (
              hvk_daily_rate_seq.CURRVAL, lv_basic_rate,
              'S', hvk_service_seq.CURRVAL
            );
        WHEN 1 THEN
          INSERT INTO hvk_daily_rate (
              daily_rate_number,   daily_rate,
              daily_rate_dog_size, serv_service_number
            ) VALUES (
              hvk_daily_rate_seq.CURRVAL, lv_basic_rate * lv_increase,
              'M', hvk_service_seq.CURRVAL
            );
        WHEN 2 THEN
          INSERT INTO hvk_daily_rate (
              daily_rate_number,   daily_rate,
              daily_rate_dog_size, serv_service_number
            ) VALUES (
              hvk_daily_rate_seq.CURRVAL, lv_basic_rate * lv_increase * lv_increase,
              'L', hvk_service_seq.CURRVAL
            );
        END CASE;
      END LOOP;
    END IF;
     DBMS_OUTPUT.PUT_LINE('The service '|| lv_desc || 'has been added.');
  ELSE
    DBMS_OUTPUT.PUT_LINE('The service already exists. Maybe you want to update the prices?');
  END IF;
END;