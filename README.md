# SeleniumInitialize

Набор задач для реализации по теме "Инициализация Selenium WebDriver"
Методы для данной задачи реализуются в классе SeleniumBuilder.cs по паттерну Builder (Строитель)

Для реализации данных задач требуется подключить nuget-пакет OpenQA.Selenium.Chrome или же самостоятельно скачать YandexDriver c репозитория https://github.com/yandex/YandexDriver и указать путь к нему напрямую при запуска экземпляра IWebDriver.

## Задача № 1:

Запустить ChromeDriver, вернув экземпляр, реализующий интерфейс IWebDriver для проверке в тесте BuildTest1, запустить тест, удостовериться в правильной инициализации.
По завершению этого теста браузер не закроется и chromedriver.exe останется в процессах. Найдите процесс и закройте вручную или с помощью кода.

## Задача № 2:

Реализовать метод Dispose интерфейса IDisposable, чтобы освободить нетронутые сборщиком мусора ресурсы. 
Текущие состояние ресурсов (освобождены или нет) должно	быть зафиксировано в переменной IsDisposed.
Исполнить тест DisposeTest1.
После прохождения тестов добавить TearDown метод (NUnit), чтобы ресурсы освобождались после каждого теста.

## Задача № 3: 

Запустить браузер в headless режиме. Этого можно добиться несколькими способами.
Самостоятельно добавьте свойство для отслеживания состояния headless в класс SeleniumBuilder и напишите тест для проверки запуска в данном режиме.
Для наглядности рекомендую отслеживать процессы в диспетчере задач, поскольку при headless запуске никаких визуальных следов браузера быть видно не должно.


### Примечание: Задание 4 можно реализовать с помощью манипулирования объектами Options и DefaultService или же с помощью изменения процесса инициализации в методе Build().
### Выбирайте способ, который вам более предпочтителен, на подумать: почему вы считаете этот способ более верным? Для интереса можно попробовать оба способа.

## Задача № 4: Запустить с заданным таймаутом.
Реализовать метод WithTimeout класса SeleniumBuilder с целью запускать браузер с заданным параметром ожидания элементов.
Изменение таймаута отслеживать в свойстве Timeout.
Пройти тест - TimeoutTest
