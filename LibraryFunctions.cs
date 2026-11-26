using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace LibraryLib
{
    /// Содержит сведения о городской библиотеке и методы работы с ними.
    public class LibraryFunctions
    {
        private string chiefLibrarian = "Комогорцев Игорь Денисович";

        // Список сотрудников городской библиотеки.
        private readonly List<string> staff = new()
        {
            "Сергеев С.С",
            "Сидорова С.С",
            "Ермолин А.С.",
            "Комогорцев И.Д."
        };

        /// Возвращает ФИО главного библиотекаря.
        public string GetChiefLibrarian()
        {
            return chiefLibrarian;
        }

        /// Возвращает название библиотеки.
        public string GetLibraryName()
        {
            return "Городская библиотека г. Чита";
        }

        /// Изменяет главного библиотекаря, если сотрудник есть в списке.
        /// Возвращает true при успешном изменении и false, если сотрудник не найден.
        public bool SetChiefLibrarian(string fullname)
        {
            if (string.IsNullOrWhiteSpace(fullname))
            {
                return false;
            }

            // Главным библиотекарем может стать только сотрудник библиотеки.
            if (!staff.Contains(fullname.Trim(), StringComparer.OrdinalIgnoreCase))
            {
                return false;
            }

            chiefLibrarian = fullname.Trim();
            return true;
        }

        /// Формирует код книги вида CAT_number.
        /// Второй параметр задаёт верхнюю границу случайного номера (включительно).
        public string GenerateBookCode(string category, int number)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                throw new ArgumentException("Категория книги не должна быть пустой.", nameof(category));
            }

            if (number < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(number), "Верхняя граница номера должна быть больше нуля.");
            }

            // Генерируем случайное число от 1 до number включительно.
            int randomNumber = RandomNumberGenerator.GetInt32(1, number + 1);
            return $"{category.Trim().ToUpperInvariant()}_{randomNumber}";
        }

        /// Возвращает копию списка сотрудников библиотеки.
        public List<string> GetStaff()
        {
            return new List<string>(staff);
        }

        /// Добавляет нового сотрудника в список.
        /// Возвращает true, если сотрудник добавлен.
        public bool AddStaff(string fullname)
        {
            if (string.IsNullOrWhiteSpace(fullname))
            {
                return false;
            }

            string normalizedFullname = fullname.Trim();

            // Не допускаем добавление одного и того же сотрудника дважды.
            if (staff.Contains(normalizedFullname, StringComparer.OrdinalIgnoreCase))
            {
                return false;
            }

            staff.Add(normalizedFullname);
            return true;
        }
    }
}
