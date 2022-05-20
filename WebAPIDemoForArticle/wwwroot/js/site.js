async function renderForecastData() {
    let apiResponse = await fetch('/weatherForecast')
    let forecasts = await apiResponse.json()

    forecasts.forEach(forecast => {
        let p = document.createElement('p')
        p.innerText = `${forecast.date} - ${forecast.temperatureF}°F/${forecast.temperatureC}°C - ${forecast.summary}`
        document.getElementById('main').appendChild(p)
    })
}
renderForecastData().then()