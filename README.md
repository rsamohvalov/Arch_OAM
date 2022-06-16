# Arch_OAM
## Интерфейсная часть проекта системы управления роботизированной техникой
1. _Кратко описать предметную область, концепцию и задачи (функционал) приложения текстом._    
   Весь проект имеет задачу - реализовать систему дистанционного мониторинга и управления движущимися объектами и различным оборудованием, установленным на них.
   Первичной целью является разработка стендовой реализации с "цифровыми двойниками" будущих элементов.
   Для домашнего задания выбрана часть системы, непосредственно реализующая взаимодействие с пользователями и минимальную часть функций управления.
   
   Интерфейс должен обеспечивать возможность:
   - компоновки новых агрегатов (тип транспорта, набор датчиков и актуаторов);
   - мониторинга состояния датчиков дейстующих агрегатов;
   - управления движением агрегатов и актуаторами на них.  
   
   В системе предусмотрены следующие пользователи:
   - оператор (мониторит и управляет работой агрегатов);
   - технолог (заводит новые элементы, в т.ч. датчики, актутаторы, транспорт, конфигурирует агрегаты);
   - администратор (заводит новых пользователей, мониторит работоспособность системы). 
   
   В качестве дополнительной внешней сущности определена некая аналитическая система, реализующая обработку данных, поступающих от объектов, и формирование событий для    уведомления операторов.
3. _Выделить домен бизнес-логики и описать его сущности в виде ER-диаграммы._ 
   [Очень простая ER диаграмма](https://github.com/rsamohvalov/Arch_OAM/blob/main/ER.jpg) 
5. _Описать функционал приложения с точки зрения пользовательских ролей в виде Use-Case диаграммы сценариев._    
   [Use-Case диаграмма](https://github.com/rsamohvalov/Arch_OAM/blob/main/Use-case.jpg)
6. _Определить вид приложения_  
   Web-приложение SPA, паттерн MVC, паттерн дооступа к данным Репозиторий.  
8. Спроектировать модули, реализующие бизнес-логику приложения (результат - UML диаграмма классов).
9. На любом объектно-ориентированном языке программирования реализовать каркас приложения в виде уровня домена бизнес-логики. Он должен содержать:
+ Основные модели (реализующие сущности домена);
+ Интерфейсы для объектов выбранного паттерна доступа к данным;
+ Заглушечные (mock) реализации этих интерфейсов;
+ Модули, реализующие описанные сценарии бизнес-логики, использующие выделенные объекты доступа к данным с помощью принципа инверсии зависимостей (через использование интерфейсов).
