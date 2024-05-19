<?php
$error = "";
$msg = "";
// Login form submission




if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['client'])) {
    $postEndpointVac = 'http://localhost:3000/api/client';
    
    // Data to be inserted
    $postData = array(
        'last_name' => $_POST['last_name'],
        'first_name' => $_POST['first_name'],
        'middle_name' => $_POST['middle_name'],
        'contact_no' => $_POST['contact_no'],
        'purok' => $_POST['purok']
    );

    // Log received data
    error_log("Received POST data: " . print_r($postData, true));

    // Create the context for the HTTP POST request
    $contextOptions = array(
        'http' => array(
            'method' => 'POST',
            'header' => 'Content-Type: application/json',
            'content' => json_encode($postData)
        )
    );

    $context = stream_context_create($contextOptions);
    $postResponse = file_get_contents($postEndpointVac, false, $context);

    // Check if the request was successful
    if ($postResponse === false) {
        $msg = "Error: Failed to insert data using the API.";
        error_log($msg);
    } else {
        $responseData = json_decode($postResponse, true);

        // Check if JSON decoding was successful
        if (json_last_error() !== JSON_ERROR_NONE) {
            $msg = "Error: Failed to decode JSON response.";
            error_log($msg);
        } else {
            $msg = "Data inserted successfully.";
            error_log("API response: " . print_r($responseData, true));
        }
    }
}




if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['menu'])) {
    // Define the directory where uploaded images will be stored
    $targetDirectory = "assets/image/";

    // Get the filename and temporary location of the uploaded image
    $imageFileName = $_FILES['image']['name'];
    $imageTempPath = $_FILES['image']['tmp_name'];

    // Generate a unique filename to avoid overwriting existing files
    $imageFilePath = $targetDirectory . uniqid() . '_' . $imageFileName;

    // Move the uploaded file to the target directory
    if (move_uploaded_file($imageTempPath, $imageFilePath)) {
        // File uploaded successfully, proceed with inserting data into the database
        $columns = array(
            "category_id",
            "name",
            "classification",
            "price",
            "date",
            "image",
            "status"
        );
        $currentDate = date("Y-m-d");
        $values = array(
            $_POST['category_id'],
            $_POST['name'],
            $_POST['classification'],
            $_POST['price'],
            $currentDate,
            $imageFilePath,
            '1' // Save the file path in the database
        );

        // Assuming $database is your instance of the database class
        $database->addData($columns, $values, "menu_tbl");
    } else {
        // Error handling if file upload fails
        echo "Sorry, there was an error uploading your file.";
    }
}
if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['employees'])) {
    $columns = array(
        "name",
        "position",
        "contact",
        "address",
        "day_of_week",
        "start_time",
        "end_time"
    );
    $values = array(
        $_POST['name'],
        $_POST['position'],
        $_POST['contact'],
        $_POST['address'],
        $_POST['day_of_week'],
        $_POST['start_time'],
        $_POST['end_time'],

    );

    $database->addData($columns, $values, "employee_tbl");
}
if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['delete_category'])) {
    $id = $_POST['delete_category']; // Corrected the variable name
    $database->deleteData("category_tbl", "id", $id);
}

if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['update_category'])) {
    // Assuming you have retrieved $id, $name, $details, and $date from your form or somewhere else
    $id = $_POST['id'];
    $name = $_POST['name'];
    $details = $_POST['details'];
    $date = $_POST['date'];

    // Assuming you have an instance of your database class named $database
    $database->updateData("category_tbl", "name", $id, $name);
    $database->updateData("category_tbl", "details", $id, $details);
    $database->updateData("category_tbl", "date", $id, $date);
}

if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['delete_menu'])) {
    $id = $_POST['delete_menu'];
    // Update the menu data in the database
    $columnsToUpdate = array(

        "status"
    );
    $valuesToUpdate = array(

        '0'
    );

    // Assuming you have an instance of your database class named $database
    foreach ($columnsToUpdate as $index => $column) {
        $database->updateData("menu_tbl", $column, $id, $valuesToUpdate[$index]);
    }
}

if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['update_menu'])) {
    // Define the directory where uploaded images will be stored
    $targetDirectory = "assets/image/";

    // Get the filename and temporary location of the uploaded image
    $imageFileName = $_FILES['image']['name'];
    $imageTempPath = $_FILES['image']['tmp_name'];

    // Generate a unique filename to avoid overwriting existing files
    $imageFilePath = $targetDirectory . uniqid() . '_' . $imageFileName;

    // Move the uploaded file to the target directory
    if (move_uploaded_file($imageTempPath, $imageFilePath)) {
        // File uploaded successfully, proceed with updating the menu data including the image path
        // Assuming you have retrieved $id, $category_id, $name, $classification, $price, and $date from your form or somewhere else
        $id = $_POST['id'];
        $category_id = $_POST['category_id'];
        $name = $_POST['name'];
        $classification = $_POST['classification'];
        $price = $_POST['price'];
        $available_qty = $_POST['available_qty'];
        $date = $_POST['date'];

        // Update the menu data in the database
        $columnsToUpdate = array(
            "category_id",
            "name",
            "classification",
            "price",
            "available_qty",
            "date",
            "image"
        );
        $valuesToUpdate = array(
            $category_id,
            $name,
            $classification,
            $price,
            $available_qty,
            $date,
            $imageFilePath // Update the file path in the database
        );

        // Assuming you have an instance of your database class named $database
        foreach ($columnsToUpdate as $index => $column) {
            $database->updateData("menu_tbl", $column, $id, $valuesToUpdate[$index]);
        }
    } else {
        $id = $_POST['id'];
        $category_id = $_POST['category_id'];
        $name = $_POST['name'];
        $classification = $_POST['classification'];
        $price = $_POST['price'];
        $date = $_POST['date'];

        // Update the menu data in the database
        $columnsToUpdate = array(
            "category_id",
            "name",
            "classification",
            "price",
            "date"

        );
        $valuesToUpdate = array(
            $category_id,
            $name,
            $classification,
            $price,
            $date,

        );

        // Assuming you have an instance of your database class named $database
        foreach ($columnsToUpdate as $index => $column) {
            $database->updateData("menu_tbl", $column, $id, $valuesToUpdate[$index]);
        }
    }
}

if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['delete_employee'])) {
    $id = $_POST['delete_employee']; // Corrected the variable name
    $database->deleteData("employee_tbl", "id", $id);
    $database->deleteData("login_tbl", "employee_id", $id);
}
if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['update_employee'])) {
    // Assuming you have retrieved $id, $name, $details, and $date from your form or somewhere else
    $id = $_POST['id'];
    $name = $_POST['name'];
    $position = $_POST['position'];
    $contact = $_POST['contact'];
    $address = $_POST['address'];
    $day_of_week = $_POST['day_of_week'];
    $start_time = $_POST['start_time'];
    $end_time = $_POST['end_time'];

    // Assuming you have an instance of your database class named $database
    $database->updateData("employee_tbl", "name", $id, $name);
    $database->updateData("employee_tbl", "position", $id, $position);
    $database->updateData("employee_tbl", "contact", $id, $contact);
    $database->updateData("employee_tbl", "address", $id, $address);
    $database->updateData("employee_tbl", "day_of_week", $id, $day_of_week);
    $database->updateData("employee_tbl", "start_time", $id, $start_time);
    $database->updateData("employee_tbl", "end_time", $id, $end_time);
}

if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['update_qty'])) {
    // Assuming you have retrieved $id, $name, $details, and $date from your form or somewhere else
    $id = $_POST['id'];
    $total_qty = $_POST['total_qty'];


    // Assuming you have an instance of your database class named $database
    $database->updateData("menu_tbl", "available_qty", $id, $total_qty);
}

if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['log'])) {
    $username = $_POST['username'];
    $password = $_POST['password'];
    // Authenticate user
    $userData = $database->authenticate($username, $password, 'login_tbl');
    if ($userData) {

        $user_id = $userData['employee_id'];
        $_SESSION['user_id'] = $user_id; // Store user_id in session variable
        $session->login($userData);
        header("Location: home.php?tab=dashboard&user_id=" . $user_id);
        exit();
    } else {
        $error = "Invalid username or password";
    }
}


if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['create'])) {
    $username = $_POST['username'];
    $password = $_POST['password'];
    $repassword = $_POST['repassword'];
    $emp_id =  $_POST['employee_id'];

    // Check if the username already exists
    $existingUser = $database->validating("username", $username, "login_tbl");
    if ($existingUser) {
        $msg = "Username already exists";
    } else {
        // Validate password match
        if ($password !== $repassword) {
            $msg = "Password doesn't match.";
        } else {
            // Add logic to insert data into database

            // Hash the password
            $hashedPassword = "BhsXkflnsm" . md5($password) . "ls0a1L2";

            // Prepare data for insertion
            $columns = array(

                "username",
                "password",
                "employee_id"
            );
            $values = array(

                $username,
                $hashedPassword,
                $emp_id
            );

            // Add data to the login_tbl
            $database->addData($columns, $values, "login_tbl");

            $msg = "Successfully Created";
        }
    }

    echo "<pre>";
    var_dump($msg);
    echo "</pre>";
}
