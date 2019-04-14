alter table HVK_PET_VACCINATION 

--- Set to 'Y' if checked, 'N' otherwise
add VACCINATION_CHECKED_STATUS char(1) default 'N' not NULL;


-- mark vaccination as checked if the pet has been in in the last 1 month
update HVK_PET_VACCINATION v
set VACCINATION_CHECKED_STATUS = 'Y'
where PET_PET_NUMBER in (
select distinct(pr.pet_pet_number) from hvk_pet_reservation pr, HVK_RESERVATION r
where r.RESERVATION_NUMBER = pr.RES_RESERVATION_NUMBER
and r.RESERVATION_END_DATE BETWEEN ADD_MONTHS(SYSDATE, -1) and SYSDATE
);