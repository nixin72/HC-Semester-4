DELETE FROM hvk_reservation WHERE reservation_number = 141;
UPDATE hvk_pet
  SET dog_size = 'M'
  WHERE pet_number = 30;
UPDATE hvk_pet_vaccination
  SET vaccination_checked_status = 'T'
  WHERE pet_pet_number = 30;
  
INSERT INTO HVK_PET (
  PET_NUMBER, PET_NAME, PET_GENDER, PET_FIXED, PET_BREED,
  PET_BIRTHDATE, OWN_OWNER_NUMBER, PET_PICTURE, DOG_SIZE, SPECIAL_NOTES
) VALUES (
  38, 'Sparly', 'M', 'F', 'Cock-A-Chon', to_date('20-04-2016','dd-mm-yyyy'), 
  18, null, 'L', 'Sparly is a very stupid dog.'
);
  
DELETE FROM hvk_pet_reservation_service
  WHERE serv_service_number = 3
    OR serv_service_number = 4;
    
DELETE FROM hvk_daily_rate
  WHERE serv_service_number = 3
    OR serv_service_number = 4;
    
DELETE FROM hvk_service 
  WHERE service_number = 3
    OR service_number = 4;
    
DROP TABLE HVK_PET_RESERVATION_DISCOUNT;
DELETE FROM HVK_DISCOUNT
  WHERE DISCOUNT_NUMBER = 1
    OR DISCOUNT_NUMBER = 3;

    
ALTER TABLE hvk_owner DROP COLUMN vet_vet_number;
ALTER TABLE HVK_PET_RESERVATION_SERVICE DROP COLUMN SERVICE_FREQUENCY;
ALTER TABLE HVK_PET_RESERVATION DROP COLUMN PR_SHARING_WITH;
DROP TABLE HVK_VETERINARIAN;
DROP TABLE HVK_MEDICATION;
DROP TABLE hvk_pet_FOOD;
DROP TABLE HVK_FOOD;