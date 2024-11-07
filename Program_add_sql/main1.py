import sqlite3

def main():
    connection_string = "SMTH.db" 
    try:
        with sqlite3.connect(connection_string) as connection:
            file_path = "CREATEDATABASECourses.sql"
            execute_sql_file(connection, file_path)
    except sqlite3.Error as e:
        print(f"Database error: {e}")

def execute_sql_file(connection, file_path):
    try:
        with open(file_path, 'r', encoding='utf-8') as file:
            sql = file.read()
        
        connection.executescript(sql)
        print("Database and tables created successfully.")
    except FileNotFoundError:
        print(f"The file {file_path} was not found.")
    except sqlite3.Error as e:
        print(f"Error executing SQL script: {e}")

if __name__ == "__main__":
    main()
