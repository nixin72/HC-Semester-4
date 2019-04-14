CREATE OR REPLACE PACKAGE hvk_tables_list_package AS 
--PART A
  PROCEDURE list_available_runs_pp (
    pv_start_date_i     hvk_reservation.reservation_start_date%TYPE,
    pv_end_date_i       hvk_reservation.reservation_end_date%TYPE,
    pv_cursor_o   OUT   SYS_REFCURSOR
  );
  
--PART B  
  PROCEDURE list_reservations_starting_pp (
    pv_start_date_i     hvk_reservation.reservation_start_date%TYPE,
    pv_cursor_o   OUT   SYS_REFCURSOR
  );
  
--PART C  
    PROCEDURE list_reservations_ending_pp (
    pv_end_date_i       hvk_reservation.reservation_end_date%TYPE,
    pv_cursor_o   OUT   SYS_REFCURSOR
  );
  
--PART D  
  PROCEDURE list_active_reservations_pp (
    pv_owner_number_i   hvk_owner.owner_number%TYPE DEFAULT null,
    pv_date_i           hvk_reservation.reservation_start_date%TYPE DEFAULT SYSDATE,
    pv_cursor_o   OUT   SYS_REFCURSOR
  );
  
--PART E  
  PROCEDURE list_active_reservations_pp (
    pv_owner_number_i   hvk_owner.owner_number%TYPE DEFAULT null,
    pv_start_date_i     hvk_reservation.reservation_start_date%TYPE,
    pv_end_date_i       hvk_reservation.reservation_end_date%TYPE,
    pv_cursor_o   OUT   SYS_REFCURSOR
  );
  
--PART F  
  PROCEDURE list_check_vaccinations_pp (
    pv_pet_number_i     hvk_pet.pet_number%TYPE,
    pv_res_number_i     hvk_reservation.reservation_number%TYPE,
    pv_cursor_o   OUT   SYS_REFCURSOR
  );
  
--Tests 
  PROCEDURE test_package_pp;
END hvk_tables_list_package;