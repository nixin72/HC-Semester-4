--owner_number
DROP SEQUENCE hvk_owner_seq;
CREATE SEQUENCE hvk_owner_seq 
  Start with 250 increment by 1;
--daily_rate_number
DROP SEQUENCE hvk_daily_rate_seq;
CREATE SEQUENCE hvk_daily_rate_seq 
  Start with 12 increment by 1;
--discount_number
DROP SEQUENCE hvk_discount_seq;
CREATE SEQUENCE hvk_discount_seq
  Start with 16 increment by 1;
--pet_res_number  
DROP SEQUENCE hvk_pet_res_seq;
CREATE SEQUENCE hvk_pet_res_seq 
  Start with 2500 increment by 1;
--pet_number 
DROP SEQUENCE hvk_pet_seq;
CREATE SEQUENCE hvk_pet_seq 
  Start with 100 increment by 1;
--reservation_number  
DROP SEQUENCE hvk_reservation_seq;
CREATE SEQUENCE hvk_reservation_seq 
  Start with 2000 increment by 1;
--run_number
DROP SEQUENCE hvk_run_seq;
CREATE SEQUENCE hvk_run_seq 
  Start with 40 increment by 1;
--service_number  
DROP SEQUENCE hvk_service_seq;
CREATE SEQUENCE hvk_service_seq 
  Start with 7 increment by 1;
--vaccination_number 
DROP SEQUENCE hvk_vaccination_seq;
CREATE SEQUENCE hvk_vaccination_seq 
  Start with 7 increment by 1;