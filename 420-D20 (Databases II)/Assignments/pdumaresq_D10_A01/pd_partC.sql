--------------------------------------------------------------------------------
------------------------------------PART C--------------------------------------
--------------------------------------------------------------------------------
DROP VIEW hvk_bill_vw;
CREATE VIEW hvk_bill_vw 
  AS 
  SELECT r.reservation_number                           AS "RESERVATION_NUMBER", 
      o.owner_number                                    AS "OWNER_NUMBER", 
      s.service_description                             AS "SERVICE_DESC", 
      pr.pet_res_number                                 AS "PET_RES_NUMBER", 
      dr.daily_rate                                     AS "DAILY_RATE", 
      r.reservation_end_date - r.reservation_start_date AS "DAYS_CHARGED",
      (r.reservation_end_date - r.reservation_start_date) * dr.daily_rate 
                                                        AS "AMOUNT_CHARGED"
  FROM hvk_reservation r, hvk_owner o, hvk_service s, hvk_pet_reservation pr, 
      hvk_daily_rate dr, hvk_pet p, hvk_pet_reservation_service prs
  WHERE   o.owner_number              = p.own_owner_number
      AND p.pet_number                = pr.pet_pet_number
      AND pr.res_reservation_number   = r.reservation_number
      AND pr.pet_res_number           = prs.pr_pet_res_number
      AND s.service_number            = prs.serv_service_number
      AND s.service_number            = dr.serv_service_number
      AND p.dog_size                  = dr.daily_rate_dog_size
      AND prs.service_frequency       IS NULL
UNION 
  SELECT r.reservation_number                           AS "RESERVATION_NUMBER", 
      o.owner_number                                    AS "OWNER_NUMBER", 
      s.service_description                             AS "SERVICE_DESC", 
      pr.pet_res_number                                 AS "PET_RES_NUMBER", 
      dr.daily_rate                                     AS "DAILY_RATE", 
      prs.service_frequency                             AS "DAYS_CHARGED",
      prs.service_frequency * dr.daily_rate             AS "AMOUNT_CHARGED"
  FROM hvk_reservation r, hvk_owner o, hvk_service s, hvk_pet_reservation pr, 
      hvk_daily_rate dr, hvk_pet p, hvk_pet_reservation_service prs
  WHERE   o.owner_number              = p.own_owner_number
      AND p.pet_number                = pr.pet_pet_number
      AND pr.res_reservation_number   = r.reservation_number
      AND pr.pet_res_number           = prs.pr_pet_res_number
      AND s.service_number            = prs.serv_service_number
      AND s.service_number            = dr.serv_service_number
      AND p.dog_size                  = dr.daily_rate_dog_size
      AND prs.service_frequency       IS NOT NULL
UNION
  SELECT r.reservation_number                           AS "RESERVATION_NUMBER", 
      o.owner_number                                    AS "OWNER_NUMBER", 
      s.service_description                             AS "SERVICE_DESC", 
      pr.pet_res_number                                 AS "PET_RES_NUMBER", 
      dr.daily_rate                                     AS "DAILY_RATE", 
      r.reservation_end_date - r.reservation_start_date AS "DAYS_CHARGED",
      (r.reservation_end_date - r.reservation_start_date) * dr.daily_rate 
                                                        AS "AMOUNT_CHARGED"
  FROM hvk_reservation r, hvk_owner o, hvk_service s, hvk_pet_reservation pr, 
      hvk_daily_rate dr, hvk_pet p, hvk_pet_reservation_service prs
  WHERE   o.owner_number              = p.own_owner_number
      AND p.pet_number                = pr.pet_pet_number
      AND pr.res_reservation_number   = r.reservation_number
      AND pr.pet_res_number           = prs.pr_pet_res_number
      AND s.service_number            = prs.serv_service_number
      AND s.service_number            = dr.serv_service_number
      AND dr.daily_rate_dog_size      IS NULL;
      
SELECT * FROM HVK_bill_vw 
  WHERE RESERVATION_NUMBER IN (102,103,105,106) ORDER BY reservation_number;

SET SERVEROUTPUT ON;
DECLARE
  lv_res_num      hvk_reservation.reservation_number%TYPE := &reservation_number;
  lv_total_before hvk_daily_rate.daily_rate%TYPE;
  lv_share_run    hvk_daily_rate.daily_rate%TYPE;
  lv_3_more_pets  hvk_daily_rate.daily_rate%TYPE;
  lv_own_food     hvk_daily_rate.daily_rate%TYPE;
  lv_total_after  hvk_daily_rate.daily_rate%TYPE;
  lv_gst          hvk_daily_rate.daily_rate%TYPE;
  lv_total        hvk_daily_rate.daily_rate%TYPE;
  lv_own_name     VARCHAR2(50);
  lv_gst_rate     CONSTANT hvk_daily_rate.daily_rate%TYPE := 0.05;
BEGIN 
  SELECT DISTINCT o.owner_first_name || ' ' ||o.owner_last_name INTO lv_own_name
    FROM hvk_owner o, hvk_bill_vw b
    WHERE b.reservation_number = lv_res_num AND b.owner_number = o.owner_number;
    
  SELECT NVL((SUM(b.amount_charged)),0) INTO lv_total_before
    FROM hvk_bill_vw b
    WHERE b.reservation_number = lv_res_num;
    
  SELECT NVL((SUM(b.amount_charged) * 0.10),0) into lv_share_run
    FROM hvk_bill_vw b, hvk_pet_reservation pr1
    WHERE b.reservation_number = lv_res_num
      AND b.service_desc       = 'Boarding'
      AND pr1.pet_res_number   = b.pet_res_number
      AND pr1.pr_sharing_with  IS NOT NULL;      
      
  SELECT NVL((SUM(b.amount_charged) * 0.07) ,0) into lv_3_more_pets
    FROM hvk_bill_vw b
    WHERE b.reservation_number = lv_res_num
      AND ( SELECT count(pr.res_reservation_number) 
              FROM hvk_pet_reservation pr
              WHERE pr.res_reservation_number = lv_res_num ) >= 3;
              
  SELECT NVL((SUM(b.amount_charged) * 0.10 ), 0.00) INTO lv_own_food
    FROM hvk_bill_vw b, hvk_pet_food pf, hvk_pet p, hvk_pet_reservation pr
    WHERE b.reservation_number     = lv_res_num
      AND pr.pet_res_number        = b.pet_res_number
      AND pr.pet_pet_number        = p.pet_number
      AND p.dog_size               = 'L'
      AND b.pet_res_number         = pf.pr_pet_res_number
      AND pf.food_food_number      = 13
      AND b.service_desc           = 'Boarding';

  lv_total_after := lv_total_before - lv_share_run - lv_3_more_pets - lv_own_food;
  lv_gst         := lv_total_after * lv_gst_rate;
  lv_total       := lv_total_after + lv_gst;
  DBMS_OUTPUT.PUT_LINE('Owner:                    ' || lv_own_name);  
  DBMS_OUTPUT.PUT_LINE('Total before discounts:   ' || to_char(lv_total_before, '$9,999.99'));  
  DBMS_OUTPUT.PUT_LINE('Shared run discount:      ' || to_char(lv_share_run, '$9,999.99'));
  DBMS_OUTPUT.PUT_LINE('Multiple pets discount:   ' || to_char(lv_3_more_pets, '$9,999.99'));
  DBMS_OUTPUT.PUT_LINE('Own food discount:        ' || to_char(lv_own_food, '$9,999.99'));
  DBMS_OUTPUT.PUT_LINE('Total after discounts:    ' || to_char(lv_total_after, '$9,999.99'));
  DBMS_OUTPUT.PUT_LINE('-------------------------------------------------');
  DBMS_OUTPUT.PUT_LINE('GST:                      ' || to_char(lv_gst, '$9,999.99'));
  DBMS_OUTPUT.PUT_LINE('-------------------------------------------------');
  DBMS_OUTPUT.PUT_LINE('Total bill:               ' || to_char(lv_total, '$9,999.99'));
  
EXCEPTION
  WHEN NO_DATA_FOUND THEN
    IF lv_own_name IS NULL THEN
      DBMS_OUTPUT.PUT_LINE('ERROR: There is no billing information for reservation ' || lv_res_num);
    END IF;
END; 