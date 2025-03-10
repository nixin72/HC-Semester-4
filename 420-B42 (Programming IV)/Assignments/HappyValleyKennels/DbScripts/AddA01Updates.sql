--- needed for Assignment #1 test cases
--- run these once before running your test cases in Assignment #1
--- setup for TC# 5
Insert into HVK_PET_RESERVATION_DISCOUNT (DISC_DISCOUNT_NUMBER,PR_PET_RES_NUMBER) values (3,400);
Insert into HVK_PET_RESERVATION_DISCOUNT (DISC_DISCOUNT_NUMBER,PR_PET_RES_NUMBER) values (3,405);


--- setup for #6
Insert into HVK_PET_RESERVATION_DISCOUNT (DISC_DISCOUNT_NUMBER,PR_PET_RES_NUMBER) values (1,400);
Insert into HVK_PET_RESERVATION_DISCOUNT (DISC_DISCOUNT_NUMBER,PR_PET_RES_NUMBER) values (1,401);

--- setup for TC 7
Insert into HVK_PET_RESERVATION (PET_RES_NUMBER,PET_PET_NUMBER,RES_RESERVATION_NUMBER,RUN_RUN_NUMBER,PR_SHARING_WITH) values (308,10,110,null,null);
Insert into HVK_RESERVATION_DISCOUNT (DISC_DISCOUNT_NUMBER,RES_RESERVATION_NUMBER) values (2,110);
Insert into HVK_PET_RESERVATION_SERVICE (SERVICE_FREQUENCY,PR_PET_RES_NUMBER,SERV_SERVICE_NUMBER) values (null,308,1);
Insert into HVK_PET_RESERVATION_SERVICE (SERVICE_FREQUENCY,PR_PET_RES_NUMBER,SERV_SERVICE_NUMBER) values (null,308,4);
Insert into HVK_PET_FOOD (PET_FOOD_FREQUENCY,PET_FOOD_QUANTITY,PR_PET_RES_NUMBER,FOOD_FOOD_NUMBER) values (1,'0.5 cup',308,7);
Insert into HVK_MEDICATION (MEDICATION_NUMBER,MEDICATION_NAME,MEDICATION_DOSAGE,MEDICATION_SPECIAL_INSTRUCT,MEDICATION_END_DATE,PR_PET_RES_NUMBER) values (10,'Medicam','15 kg',null,null,308);