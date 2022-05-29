async function createForecast() {
    let date = document.getElementById('date').value
    let temperatureC = document.getElementById('temperatureC').value
    let summary = document.getElementById('summary').value

    await fetch('/weatherForecast', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            Date: date,
            TemperatureC: temperatureC,
            Summary: summary
        })
    })
    window.location = "/"
}

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