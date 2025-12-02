Задание 1

Задание: Напишите обобщенный интерфейс IRepository<T>, который содержит методы для работы с данными типа T: void Add(T item), void Delete(T item), T FindById(int id) и IEnumerable<T> GetAll(). Затем напишите ограничение для этого интерфейса, чтобы он мог работать только с типами, которые реализуют интерфейс IEntity, который содержит свойство Id типа int. Затем напишите классы Product и Customer, которые реализуют интерфейс IEntity и имеют свои свойства, такие как Name, Price, Address и т.д. Затем напишите классы ProductRepository и CustomerRepository, которые реализуют интерфейс IRepository<T> для типов Product и Customer соответственно и используют коллекцию типа List<T> для хранения данных.

Результат:

<img width="257" height="184" alt="изображение" src="https://github.com/user-attachments/assets/c701e42e-ecba-484d-8f53-23eb8b867813" />
