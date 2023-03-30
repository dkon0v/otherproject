//система управления проектами, использующая базу данных SQL для хранения и управления информацией о проектах, задачах и сотрудниках://

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjectManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в систему управления проектами!");

            // Подключение к базе данных
            string connectionString = "Server=localhost;Database=ProjectManagementDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Показать главное меню
                while (true)
                {
                    ShowMainMenu();

                    // Считать выбор пользователя
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            // Создать новый проект
                            CreateNewProject(connection);
                            break;
                        case 2:
                            // Показать список проектов
                            ShowProjectsList(connection);
                            break;
                        case 3:
                            // Управление задачами в проекте
                            ProjectTasksManagement(connection);
                            break;
                        case 4:
                            // Управление сотрудниками
                            EmployeesManagement(connection);
                            break;
                        case 5:
                            // Выход из программы
                            Console.WriteLine("Спасибо за использование системы управления проектами!");
                            return;
                        default:
                            Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                            break;
                    }
                }
            }
        }

        // Показать главное меню
        static void ShowMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Создать новый проект");
            Console.WriteLine("2. Показать список проектов");
            Console.WriteLine("3. Управление задачами в проекте");
            Console.WriteLine("4. Управление сотрудниками");
            Console.WriteLine("5. Выход");
            Console.WriteLine();
        }

        // Создать новый проект
        static void CreateNewProject(SqlConnection connection)
        {
            Console.WriteLine("Введите название проекта:");
            string name = Console.ReadLine();

            Console.WriteLine("Введите описание проекта:");
            string description = Console.ReadLine();

            Console.WriteLine("Введите дату начала проекта в формате ГГГГ-ММ-ДД:");
            DateTime startDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Введите дату окончания проекта в формате ГГГГ-ММ-ДД:");
            DateTime endDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Введите бюджет проекта:");
            decimal budget = decimal.Parse(Console.ReadLine());

            // Создать новую запись в таблице Projects
            SqlCommand command = new SqlCommand(
                "INSERT INTO Projects (Name, Description, StartDate, EndDate, Budget) " +
                "VALUES (@Name, @Description, @StartDate, @EndDate, @Budget)", connection);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Description", description);
            command.Parameters.AddWithValue("@StartDate", startDate);
            command.Parameters.AddWithValue("@EndDate", endDate);
            command.Parameters.AddWithValue("@Budget", budget);
        }
    }
}

