using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumInitialize_Builder
{
    public class SeleniumBuilder : IDisposable
    {
        private IWebDriver WebDriver { get; set; }
        public int Port { get; private set; }
        public bool IsDisposed { get; private set; }
        public List<string> ChangedArguments { get; private set; }
        public Dictionary<string, object> ChangedUserOptions { get; private set; }
        public TimeSpan Timeout { get; private set; }
        public string StartingURL { get; private set; }

        public IWebDriver Build()
        {
            ChromeOptions chromeOptions = new();

            if (ChangedUserOptions is not null)
            {
                foreach (KeyValuePair<string, object> changedUserOption in ChangedUserOptions)
                {
                    chromeOptions.AddAdditionalOption(changedUserOption.Key, changedUserOption.Value);
                }
            }

            if (ChangedArguments is not null)
            {
                chromeOptions.AddArguments(ChangedArguments);
            }

            ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
            if (Port is not default(int))
            {
                chromeDriverService.Port = Port;
            }

            WebDriver = new ChromeDriver(options: chromeOptions, service: chromeDriverService);
            WebDriver.Manage().Timeouts().ImplicitWait = Timeout;
            if (!string.IsNullOrEmpty(StartingURL))
            {
                WebDriver.Url = StartingURL;
            }

            //Создать экземпляр драйвера, присвоить получившийся результат переменной WebDriver, вернуть в качестве результата данного метода.

            IsDisposed = false;

            return WebDriver;
        }

        public void Dispose()
        {
            //Закрыть браузер, очистить использованные ресурсы, по завершении переключить IsDisposed на состояние true
            WebDriver.Close();
            WebDriver.Dispose();
            IsDisposed = true;
        }

        public SeleniumBuilder ChangePort(int port)
        {
            //Реализовать смену порта, на котором развёрнут IWebDriver для этого необходимо ознакомиться с классом DriverService соответствующего драйвера (ChromeDriverService для хрома)
            //Изменить свойство Port на тот порт, на который поменяли.
            //Builder в данном методе должен возвращать сам себя
            
            Port = port;

            return this;
        }

        public SeleniumBuilder SetArgument(string argument)
        {
            //Реализовать добавление аргумента. При решении данной задаче ознакомитесь с классом Options соответствующего драйвера (ChromeOptions для браузера Chrome)
            //Все изменённые/добавленные аргументы необходимо отразить в свойстве СhangedArguments, которое перед этим нужно где-то будет проинициализировать.
            //Builder в данном методе должен возвращать сам себя
            
            ChangedArguments = new()
            {
                argument
            };

            return this;
        }

        public SeleniumBuilder SetUserOption(string option, object value)
        {
            //Реализовать добавление пользовательской настройки.
            //Все изменения сохранить в свойстве ChangedUserOptions
            //Builder в данном методе должен возвращать сам себя
            ChangedUserOptions = new()
            {
                { option, value }
            };

            return this;
        }

        public SeleniumBuilder WithTimeout(TimeSpan timeout)
        {
            //Реализовать изменение изначального таймаута запускаемого браузера
            //Отслеживать изменения в свойстве Timeout
            //Builder возвращает себя
            Timeout = timeout;

            return this;
        }

        public SeleniumBuilder WithURL(string url)
        {
            //Реализовать изменения изначального URL запускаемого браузера
            //Отслеживать изменения в строке StartingURL
            //Builder возвращает себя
            StartingURL = url;

            return this;
        }
    }
}