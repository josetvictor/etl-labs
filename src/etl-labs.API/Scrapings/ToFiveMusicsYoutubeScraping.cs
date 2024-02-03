using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace etl_labs.API.Scrapings;

public class ToFiveMusicsYoutubeScraping
{

    private readonly string _url;

    public ToFiveMusicsYoutubeScraping()
    {
        _url = "https://www.youtube.com/feed/trending?bp=4gINGgt5dG1hX2NoYXJ0cw%3D%3D";
    }

    public List<Video> topVideos = new List<Video>();
    public void Scraping()
    {
        try
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");

            using (var driver = new ChromeDriver(options))
            {
                driver.Navigate().GoToUrl(_url);

                // TO DO: raspagem dos filmes
                var divContentVideos = driver.FindElement(By.Id("contents"));
                var listTopFive = divContentVideos.FindElements(By.ClassName("text-wrapper"));
                topVideos.Clear();

                for(int i = 0; i < 5; i++)
                {
                    var ancora = listTopFive[i].FindElement(By.Id("video-title"));
                    topVideos.Add(new Video
                    {
                        position = i+1,
                        Name = ancora.GetDomProperty("title"),
                        Link = ancora.GetDomProperty("href")
                    });
                }

                driver.Quit();
            }
        }
        catch (Exception err)
        {
            throw new Exception(err.Message);
        }
    }
}