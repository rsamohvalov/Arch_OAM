# Arch_OAM
## Интерфейсная часть проекта системы управления роботизированной техникой
1. Кратко описать предметную область, концепцию и задачи (функционал) приложения текстом. Рекомендуемый объём — полстраницы.  
   Весь проект имеет задачу - реализовать систему дистанционного мониторинга и управления движущимися объектами и различным оборудованием, установленным на них.
   Первичной целью является разработка стендовой реализации с "цифровыми двойниками" будущих элементов.
   Для домашнего задания выбрана часть системы, непосредственно реализующая взаимодействие с пользователями и минимальную часть функций управления.
   
   Интерфейс должен обеспечивать возможность:
   - компоновки новых объектов (тип транспорта, набор датчиков и актуаторов);
   - мониторинга состояния датчиков дейстующих объектов;
   - управления движением объекта и актуаторами на нем.  
   
   В системе предусмотрены следующие пользователи:
   - оператор (мониторит и управляет работой объектов, при необходимости);
   - администратор оборудования (заводит новые элементы, в т.ч. датчики, актутаторы, транспорт, конфигурирует объекты);
   - администратор системы (заводит новых пользователей, мониторит работоспособность системы). 
   
   В качестве дополнительной внешней сущности определена некая аналитическая система, реализующая обработку данных, поступающих от объектов, и формирование событий для    уведомления операторов.
3. Выделить домен бизнес-логики и описать его сущности в виде ER-диаграммы.
4. Описать функционал приложения с точки зрения пользовательских ролей в виде Use-Case диаграммы сценариев. 
5. Определить вид приложения (монолитное десктопное приложение, клиент-серверное десктопное приложение, клиент-серверное мобильное приложение, web-приложение MPA, web-приложение SPA). Выбрать и обосновать выбор архитектурного паттерна и паттерна доступа к данным. Можно текстом. Стандартным решением на этом шаге будет MPA приложение на базе паттерна MVC.
6. Спроектировать модули, реализующие бизнес-логику приложения (результат - UML диаграмма классов).
7. На любом объектно-ориентированном языке программирования реализовать каркас приложения в виде уровня домена бизнес-логики. Он должен содержать:
+ Основные модели (реализующие сущности домена);
+ Интерфейсы для объектов выбранного паттерна доступа к данным;
+ Заглушечные (mock) реализации этих интерфейсов;
+ Модули, реализующие описанные сценарии бизнес-логики, использующие выделенные объекты доступа к данным с помощью принципа инверсии зависимостей (через использование интерфейсов).
