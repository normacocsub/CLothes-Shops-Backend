using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;




List<IWebDriver> navegadores = new()
{
    { new ChromeDriver() },
    { new EdgeDriver() },
    { new FirefoxDriver() },
};
foreach (var item in navegadores)
{
    IWebDriver driver = item;
    driver.Navigate().GoToUrl("https://clothes-shops.vercel.app");

    //RegistroProveedor(driver);
    //RegistroUsuario(driver);
    RegistroProducto(driver);

    Thread.Sleep(TimeSpan.FromSeconds(5));
    driver.Quit();
    Console.WriteLine("Chrome, Edge y Firefox, se han ejecutado correctamente las pruebas de portabilidad.");
}






void Login(IWebDriver driver)
{
    IWebElement button = driver.FindElement(By.Id("login-button"));
    button.Click();
    Thread.Sleep(TimeSpan.FromSeconds(3));

    IWebElement email = driver.FindElement(By.Id("email"));
    email.SendKeys("admin123@gmail.com");
    IWebElement password = driver.FindElement(By.Id("password"));
    password.SendKeys("Hola123*");

    IWebElement loginButton = driver.FindElement(By.Id("login"));
    loginButton.Click();

    Thread.Sleep(TimeSpan.FromSeconds(3));
}

void RegistroProducto(IWebDriver driver)
{
    Login(driver);

    IWebElement RopaButton = driver.FindElement(By.Id("ropa"));
    RopaButton.Click();


    driver.Navigate().GoToUrl("http://localhost:3000/admin/clothes/registro");
    Thread.Sleep(TimeSpan.FromSeconds(3));
    string projectRootDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\.."));
    string fileName = "login.jpg";
    string filePath = Path.Combine(projectRootDirectory, fileName);
    IWebElement fileInput = driver.FindElement(By.Id("photoInput"));
    fileInput.SendKeys(filePath);
    Thread.Sleep(TimeSpan.FromSeconds(5));

    IWebElement nombre = driver.FindElement(By.Id("nombre"));
    nombre.SendKeys("Prueba");

    IWebElement descripcion = driver.FindElement(By.Id("descripcion"));
    descripcion.SendKeys("Prueba");
    IWebElement stock = driver.FindElement(By.Id("stock"));
    stock.SendKeys("15");

    IWebElement selectElement = driver.FindElement(By.Id("categoria"));
    SelectElement selectCategoria = new SelectElement(selectElement);
    selectCategoria.SelectByValue("2");
    IWebElement selectProveedor = driver.FindElement(By.Id("proveedorSelect"));
    SelectElement selectProv = new SelectElement(selectProveedor);
    selectProv.SelectByValue("123456789");

    IWebElement precio = driver.FindElement(By.Id("precio"));
    precio.SendKeys("150000");


    IWebElement guardarButton = driver.FindElement(By.Id("registro"));
    guardarButton.Click();
}
void RegistroProveedor(IWebDriver driver)
{
    Login(driver);
    IWebElement RopaButton = driver.FindElement(By.Id("proveedor"));
    RopaButton.Click();
    
    
    driver.Navigate().GoToUrl("http://localhost:3000/admin/proveedores/registro");
    Thread.Sleep(TimeSpan.FromSeconds(3));

    IWebElement id = driver.FindElement(By.Id("id"));
    id.SendKeys("123456789");
    IWebElement nombre = driver.FindElement(By.Id("nombre"));
    nombre.SendKeys("Prueba");
    IWebElement apellido = driver.FindElement(By.Id("apellido"));
    apellido.SendKeys("Prueba");
    IWebElement direccion = driver.FindElement(By.Id("direccion"));
    direccion.SendKeys("Valledupar");
    IWebElement telefono = driver.FindElement(By.Id("telefono"));
    telefono.SendKeys("1234567891");
    IWebElement ciudad = driver.FindElement(By.Id("ciudad"));
    ciudad.SendKeys("Valledupar");
    IWebElement correo = driver.FindElement(By.Id("correo"));
    correo.SendKeys("Prueba1@gmail.com");
    IWebElement buttonGuardar = driver.FindElement(By.Id("guardar"));
    buttonGuardar.Click();
    Thread.Sleep(TimeSpan.FromSeconds(3));
    Console.WriteLine("Finish Test Integration Proveedor");
}


void RegistroUsuario(IWebDriver driver)
{
    IWebElement button = driver.FindElement(By.Id("login-button"));
    button.Click();
    Thread.Sleep(TimeSpan.FromSeconds(3));



    IWebElement registro = driver.FindElement(By.Id("registro"));
    registro.Click();


    
    Thread.Sleep(TimeSpan.FromSeconds(3));

    IWebElement id = driver.FindElement(By.Id("id"));
    id.SendKeys("123456788");
    IWebElement nombre = driver.FindElement(By.Id("nombre"));
    nombre.SendKeys("Prueba");
    IWebElement apellido = driver.FindElement(By.Id("apellido"));
    apellido.SendKeys("Prueba");
    IWebElement direccion = driver.FindElement(By.Id("direccion"));
    direccion.SendKeys("Valledupar");
    IWebElement telefono = driver.FindElement(By.Id("telefono"));
    telefono.SendKeys("1234567891");
    IWebElement ciudad = driver.FindElement(By.Id("ciudad"));
    ciudad.SendKeys("Valledupar");
    IWebElement correo = driver.FindElement(By.Id("correo"));
    correo.SendKeys("Prueba2@gmail.com");
    IWebElement password = driver.FindElement(By.Id("password"));
    password.SendKeys("Hola12345*");
    IWebElement buttonGuardar = driver.FindElement(By.Id("guardar"));
    buttonGuardar.Click();
    Thread.Sleep(TimeSpan.FromSeconds(3));
    Console.WriteLine("Finish Test Integration Usuario");
}


