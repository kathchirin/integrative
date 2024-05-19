<?php

class Database
{
    private $pdo;

    public function __construct($dsn, $db_user, $db_pw)
    {
        try {
            $this->pdo = new PDO($dsn, $db_user, $db_pw);
            $this->pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
        } catch (PDOException $e) {
            die("Connection failed: " . $e->getMessage());
        }
    }



    public function authenticate($username, $password, $tablename)
    {
        // Hash the provided password

        $hashedPassword = "BhsXkflnsm" . md5($password) . "ls0a1L2";
        // Prepare and execute the query
        $stmt = $this->pdo->prepare("SELECT * FROM {$tablename} WHERE username = ? AND password = ?");
        $stmt->execute([$username, $hashedPassword]);

        // Fetch the user data
        return $stmt->fetch(PDO::FETCH_ASSOC);
    }

    public function getAllEmployeeIDs()
    {
        $stmt = $this->pdo->prepare("SELECT id FROM employee_tbl");
        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_COLUMN);
    }

    public function validating($column, $value, $table)
    {
        $stmt = $this->pdo->prepare("SELECT * FROM {$table} WHERE {$column} = :value");
        $stmt->bindParam(':value', $value);
        $stmt->execute();

        return $stmt->fetch(PDO::FETCH_ASSOC);
    }
    public function validating1($column, $value, $table)
    {
        // Assuming PDO is already initialized and available as $this->pdo

        // Use a JOIN query to fetch the employee name
        $stmt = $this->pdo->prepare("
        SELECT e.name 
        FROM login_tbl a 
        JOIN {$table} e ON a.employee_id = e.id 
        WHERE a.{$column} = :value
    ");
        $stmt->bindParam(':value', $value);
        $stmt->execute();

        return $stmt->fetch(PDO::FETCH_ASSOC);
    }

    public function addData($columns, $values, $tablename)
    {
        $columnNames = implode(',', $columns);
        $placeholders = implode(',', array_fill(0, count($columns), '?'));
        $stmt = $this->pdo->prepare("INSERT INTO {$tablename} ({$columnNames}) VALUES ({$placeholders})");
        $stmt->execute($values);
    }

    public function getAllData($tablename)
    {
        $stmt = $this->pdo->prepare("SELECT * FROM {$tablename}");
        $stmt->execute();
        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }

    public function getEmpData($tablename)
    {
        $stmt = $this->pdo->prepare("SELECT id, name, contact, address, day_of_week as Day of the week, start_time as Start time, end_time as end time FROM {$tablename}");
        $stmt->execute();
        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }

    public function updateData($tablename, $column, $id, $newData)
    {
        $stmt = $this->pdo->prepare("UPDATE {$tablename} SET {$column} = :newData WHERE id = :id");
        $stmt->bindParam(':newData', $newData);
        $stmt->bindParam(':id', $id);
        $stmt->execute();
    }

    public function deleteData($tablename, $column, $value)
    {
        $stmt = $this->pdo->prepare("DELETE FROM {$tablename} WHERE {$column} = :value");
        $stmt->bindParam(':value', $value);
        $stmt->execute();
    }


    public function getMenuData($tablename)
    {
        $stmt = $this->pdo->prepare("
        SELECT 
            m.id,
            m.name AS menu_name,
            c.name AS category_name,
            m.classification,
            m.price,
            m.available_qty
        
            
        FROM 
            {$tablename} AS m
        INNER JOIN 
            category_tbl AS c ON m.category_id = c.id
        WHERE 
            m.status = 1;
    ");
        $stmt->execute();
        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }


    public function getDataById($tablename, $id)
    {
        $stmt = $this->pdo->prepare("SELECT * FROM {$tablename} WHERE id = ?");
        $stmt->execute([$id]);
        return $stmt->fetch(PDO::FETCH_ASSOC);
    }
    public function getCount($tablename)
    {
        $stmt = $this->pdo->prepare("SELECT COUNT(*) as totalCount FROM {$tablename} ");
        $stmt->execute();
        $row = $stmt->fetch(PDO::FETCH_ASSOC);
        return $row['totalCount'];
    }
    public function getCountMenu($tablename)
    {
        $stmt = $this->pdo->prepare("SELECT COUNT(*) as totalCount FROM {$tablename} Where status = '1' ");
        $stmt->execute();
        $row = $stmt->fetch(PDO::FETCH_ASSOC);
        return $row['totalCount'];
    }
    public function updateQty($tablename, $column, $id, $newData)
    {
        $stmt = $this->pdo->prepare("UPDATE {$tablename} SET {$column} = :newData WHERE id = :id");
        $stmt->bindParam(':newData', $newData);
        $stmt->bindParam(':id', $id);
        $stmt->execute();
    }

    public function getOrderedData($order_id)
    {
        $stmt = $this->pdo->prepare("
        SELECT ordered_menu.order_id, menu_tbl.name AS menu_name,menu_tbl.price, ordered_menu.quantity, (menu_tbl.price * ordered_menu.quantity) AS Subtotal
        FROM ordered_menu 
        INNER JOIN menu_tbl ON ordered_menu.menu_id = menu_tbl.id 
        WHERE ordered_menu.order_id = ?
    ");
        $stmt->execute([$order_id]);
        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }

    public function getOrderDetails($order_id)
    {
        $stmt = $this->pdo->prepare("
            SELECT total_amount, cash, `change`
            FROM order_tbl
            WHERE id = ?
        ");
        $stmt->execute([$order_id]);
        return $stmt->fetch(PDO::FETCH_ASSOC);
    }

    public function getTotalSales($tablename)
    {
        $stmt = $this->pdo->prepare("SELECT SUM(total_amount) AS total_sales FROM {$tablename}");
        $stmt->execute();
        $result = $stmt->fetch(PDO::FETCH_ASSOC);

        $formatted_sales = number_format($result['total_sales'], 2); // Format to two decimal places

        return $formatted_sales;
    }

    public function getSalesToday($tablename)
    {
        // Set the timezone to Manila (Philippine Time)
        date_default_timezone_set('Asia/Manila');

        // Get today's date in the correct format
        $today = date('Y-m-d');

        // Prepare and execute the SQL query
        $stmt = $this->pdo->prepare("SELECT SUM(total_amount) AS total_sales FROM $tablename WHERE DATE(order_date) = :today");
        $stmt->bindValue(':today', $today, PDO::PARAM_STR);
        $stmt->execute();
        $result = $stmt->fetch(PDO::FETCH_ASSOC);

        // Format the total sales amount
        $formatted_sale = number_format($result['total_sales'], 2); // Format to two decimal places

        return $formatted_sale;
    }

    public function getTotalOrders($tablename)
    {
        $stmt = $this->pdo->prepare("SELECT COUNT(*) AS total_orders FROM $tablename");
        $stmt->execute();
        $result = $stmt->fetch(PDO::FETCH_ASSOC);

        return $result['total_orders'];
    }
    public function getData()
    {
        $sql = "SELECT menu_tbl.name, SUM(ordered_menu.quantity) as total_sold
            FROM ordered_menu
            INNER JOIN menu_tbl ON ordered_menu.menu_id = menu_tbl.id
            GROUP BY menu_tbl.name";

        $stmt = $this->pdo->prepare($sql);
        $stmt->execute();

        $menu_names = [];
        $total_sold = [];

        while ($row = $stmt->fetch(PDO::FETCH_ASSOC)) {
            $menu_names[] = $row['name'];
            $total_sold[] = $row['total_sold'];
        }

        return [
            'menu_names' => $menu_names,
            'total_sold' => $total_sold
        ];
    }

    public function getTotalSalesByDay()
    {
        // Query to fetch total sales by day
        $sql = "SELECT DATE(order_date) AS order_day, SUM(total_amount) AS total_sales
                FROM order_tbl
                GROUP BY DATE(order_date)";

        $stmt = $this->pdo->prepare($sql);
        $stmt->execute();

        $order_days = [];
        $total_sales = [];

        while ($row = $stmt->fetch(PDO::FETCH_ASSOC)) {
            $order_days[] = $row['order_day'];
            $total_sales[] = $row['total_sales'];
        }

        return [
            'order_days' => $order_days,
            'total_sales' => $total_sales
        ];
    }
}
