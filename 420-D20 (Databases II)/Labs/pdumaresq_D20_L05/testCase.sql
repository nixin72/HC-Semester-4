DECLARE
  lv_num_employees NUMBER;
  CURSOR lcur_new_salaries_all
  IS
    SELECT employeeid, deptid, positionid, salary FROM nn_employee;
BEGIN
  -------------------------- TEST CASE 1 --------------------------
  d20_L05_give_raise_sp( pv_percentage_raise_i => 10, pv_num_employees_o => lv_num_employees);
  IF lv_num_employees = 8 THEN
    dbms_output.put_line('Test case 1 successful');
  ELSE
    dbms_output.put_line('Test case 1 failed. lv_num_employees is '|| lv_num_employees);
  END IF;
  FOR lrec_employee IN lcur_new_salaries_all
  LOOP
    CASE lrec_employee.employeeid
    WHEN 111 THEN
      IF lrec_employee.salary <> 291500 THEN
        dbms_output.put_line('Test case 1. Employee '||lrec_employee.employeeid||' has incorrect salary: '||lrec_employee.salary);
      END IF;
    WHEN 246 THEN
      IF lrec_employee.salary <> 165000 THEN
        dbms_output.put_line('Test case 1. Employee '||lrec_employee.employeeid||' has incorrect salary: '||lrec_employee.salary);
      END IF;
    WHEN 123 THEN
      IF lrec_employee.salary <> 82500 THEN
        dbms_output.put_line('Test case 1. Employee '||lrec_employee.employeeid||' has incorrect salary: '||lrec_employee.salary);
      END IF;
    WHEN 433 THEN
      IF lrec_employee.salary <> 73150 THEN
        dbms_output.put_line('Test case 1. Employee '||lrec_employee.employeeid||' has incorrect salary: '||lrec_employee.salary);
      END IF;
    WHEN 543 THEN
      IF lrec_employee.salary <> 88000 THEN
        dbms_output.put_line('Test case 1. Employee '||lrec_employee.employeeid||' has incorrect salary: '||lrec_employee.salary);
      END IF;
    WHEN 200 THEN
      IF lrec_employee.salary <> 26950 THEN
        dbms_output.put_line('Test case 1. Employee '||lrec_employee.employeeid||' has incorrect salary: '||lrec_employee.salary);
      END IF;
    WHEN 135 THEN
      IF lrec_employee.salary <> 49500 THEN
        dbms_output.put_line('Test case 1. Employee '||lrec_employee.employeeid||' has incorrect salary: '||lrec_employee.salary);
      END IF;
    WHEN 222 THEN
      IF lrec_employee.salary <> 38500 THEN
        dbms_output.put_line('Test case 1. Employee '||lrec_employee.employeeid||' has incorrect salary: '||lrec_employee.salary);
      END IF;
    END CASE;
  END LOOP;
  ROLLBACK;
  -------------------------- TEST CASE 2 --------------------------
  d20_L05_give_raise_sp( pv_percentage_raise_i => 15, pv_deptid_i => 10, pv_num_employees_o => lv_num_employees);
  IF lv_num_employees = 2 THEN
    dbms_output.put_line('Test case 2 successful');
  ELSE
    dbms_output.put_line('Test case 2 failed. lv_num_employees is '|| lv_num_employees);
  END IF;
  FOR lrec_employee IN lcur_new_salaries_all
  LOOP
    CASE lrec_employee.employeeid
    WHEN 111 THEN
      IF lrec_employee.salary <> 265000 THEN
        dbms_output.put_line('Test case 2. Employee '||lrec_employee.employeeid||' has incorrect salary: '||lrec_employee.salary);
      END IF;
    WHEN 246 THEN
      IF lrec_employee.salary <> 150000 THEN
        dbms_output.put_line('Test case 2. Employee '||lrec_employee.employeeid||' has incorrect salary: '||lrec_employee.salary);
      END IF;
    WHEN 123 THEN
      IF lrec_employee.salary <> 86250 THEN
        dbms_output.put_line('Test case 2. Employee '||lrec_employee.employeeid||' has incorrect salary: '||lrec_employee.salary);
      END IF;
    WHEN 433 THEN
      IF lrec_employee.salary <> 66500 THEN
        dbms_output.put_line('Test case 2. Employee '||lrec_employee.employeeid||' has incorrect salary: '||lrec_employee.salary);
      END IF;
    WHEN 543 THEN
      IF lrec_employee.salary <> 80000 THEN
        dbms_output.put_line('Test case 2. Employee '||lrec_employee.employeeid||' has incorrect salary: '||lrec_employee.salary);
      END IF;
    WHEN 200 THEN
      IF lrec_employee.salary <> 24500 THEN
        dbms_output.put_line('Test case 2. Employee '||lrec_employee.employeeid||' has incorrect salary: '||lrec_employee.salary);
      END IF;
    WHEN 135 THEN
      IF lrec_employee.salary <> 45000 THEN
        dbms_output.put_line('Test case 2. Employee '||lrec_employee.employeeid||' has incorrect salary: '||lrec_employee.salary);
      END IF;
    WHEN 222 THEN
      IF lrec_employee.salary <> 40250 THEN
        dbms_output.put_line('Test case 2. Employee '||lrec_employee.employeeid||' has incorrect salary: '||lrec_employee.salary);
      END IF;
    END CASE;
  END LOOP;
  ROLLBACK;
  -------------------------- TEST CASE 3 --------------------------
  d20_L05_give_raise_sp( pv_percentage_raise_i => 20, pv_positionid_i => 2, pv_num_employees_o => lv_num_employees);
  IF lv_num_employees = 4 THEN
    dbms_output.put_line('Test case 3 successful');
  ELSE
    dbms_output.put_line('Test case 3 failed. lv_num_employees is '|| lv_num_employees);
  END IF;
  FOR lrec_employee IN lcur_new_salaries_all
  LOOP
    CASE lrec_employee.employeeid
    WHEN 111 THEN
      IF lrec_employee.salary <> 265000 THEN
        dbms_output.put_line('Test case 3. Employee '||lrec_employee.employeeid||' has incorrect salary: '||lrec_employee.salary);
      END IF;
    WHEN 246 THEN
      IF lrec_employee.salary <> 180000 THEN
        dbms_output.put_line('Test case 3. Employee '||lrec_employee.employeeid||' has incorrect salary: '||lrec_employee.salary);
      END IF;
    WHEN 123 THEN
      IF lrec_employee.salary <> 90000 THEN
        dbms_output.put_line('Test case 3. Employee '||lrec_employee.employeeid||' has incorrect salary: '||lrec_employee.salary);
      END IF;
    WHEN 433 THEN
      IF lrec_employee.salary <> 66500 THEN
        dbms_output.put_line('Test case 3. Employee '||lrec_employee.employeeid||' has incorrect salary: '||lrec_employee.salary);
      END IF;
    WHEN 543 THEN
      IF lrec_employee.salary <> 96000 THEN
        dbms_output.put_line('Test case 3. Employee '||lrec_employee.employeeid||' has incorrect salary: '||lrec_employee.salary);
      END IF;
    WHEN 200 THEN
      IF lrec_employee.salary <> 24500 THEN
        dbms_output.put_line('Test case 3. Employee '||lrec_employee.employeeid||' has incorrect salary: '||lrec_employee.salary);
      END IF;
    WHEN 135 THEN
      IF lrec_employee.salary <> 54000 THEN
        dbms_output.put_line('Test case 3. Employee '||lrec_employee.employeeid||' has incorrect salary: '||lrec_employee.salary);
      END IF;
    WHEN 222 THEN
      IF lrec_employee.salary <> 35000 THEN
        dbms_output.put_line('Test case 3. Employee '||lrec_employee.employeeid||' has incorrect salary: '||lrec_employee.salary);
      END IF;
    END CASE;
  END LOOP;
  ROLLBACK;
  -------------------------- TEST CASE 4 --------------------------
  d20_L05_give_raise_sp( pv_percentage_raise_i => 25, pv_deptid_i => 20, pv_positionid_i => 2, pv_num_employees_o => lv_num_employees);
  IF lv_num_employees = 2 THEN
    dbms_output.put_line('Test case 4 successful');
  ELSE
    dbms_output.put_line('Test case 4 failed. lv_num_employees is '|| lv_num_employees);
  END IF;
  FOR lrec_employee IN lcur_new_salaries_all
  LOOP
    CASE lrec_employee.employeeid
    WHEN 111 THEN
      IF lrec_employee.salary <> 265000 THEN
        dbms_output.put_line('Test case 4. Employee '||lrec_employee.employeeid||' has incorrect salary: '||lrec_employee.salary);
      END IF;
    WHEN 246 THEN
      IF lrec_employee.salary <> 187500 THEN
        dbms_output.put_line('Test case 4. Employee '||lrec_employee.employeeid||' has incorrect salary: '||lrec_employee.salary);
      END IF;
    WHEN 123 THEN
      IF lrec_employee.salary <> 75000 THEN
        dbms_output.put_line('Test case 4. Employee '||lrec_employee.employeeid||' has incorrect salary: '||lrec_employee.salary);
      END IF;
    WHEN 433 THEN
      IF lrec_employee.salary <> 66500 THEN
        dbms_output.put_line('Test case 4. Employee '||lrec_employee.employeeid||' has incorrect salary: '||lrec_employee.salary);
      END IF;
    WHEN 543 THEN
      IF lrec_employee.salary <> 100000 THEN
        dbms_output.put_line('Test case 4. Employee '||lrec_employee.employeeid||' has incorrect salary: '||lrec_employee.salary);
      END IF;
    WHEN 200 THEN
      IF lrec_employee.salary <> 24500 THEN
        dbms_output.put_line('Test case 4. Employee '||lrec_employee.employeeid||' has incorrect salary: '||lrec_employee.salary);
      END IF;
    WHEN 135 THEN
      IF lrec_employee.salary <> 45000 THEN
        dbms_output.put_line('Test case 4. Employee '||lrec_employee.employeeid||' has incorrect salary: '||lrec_employee.salary);
      END IF;
    WHEN 222 THEN
      IF lrec_employee.salary <> 35000 THEN
        dbms_output.put_line('Test case 4. Employee '||lrec_employee.employeeid||' has incorrect salary: '||lrec_employee.salary);
      END IF;
    END CASE;
  END LOOP;
  ROLLBACK;
END;