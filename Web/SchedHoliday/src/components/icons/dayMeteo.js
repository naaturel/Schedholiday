export function getDay(meteo){
    let day = []
    day.push(meteo[0])
    let i = 0
    meteo.forEach(element => {
        if((day[i].dt + 86400) == element.dt){
            day.push(element)
            i++
        }
    })
    
    return day
}

export function getWeather(weather){
    let meteo = ""
    switch(weather){
        case("Thunderstorm"):
            meteo = "Orageux"
            break
        case("Drizzle"):
            meteo = "Grosse pluie"
            break
        case("Rain"):
            meteo = "Pluvieux"
            break
        case("Snow"):
            meteo = "Neigeux"
            break
        case("Clear"):
            meteo = "Ensoleillé"
            break
        case("Clouds"):
            meteo = "Nuageux"
            break
        default:
            meteo = "Brouillard"
    }
    return meteo
}

export function getIcon(icon){
    const name = `ic_${icon.substr(0, 2)}d`
    return `../img/imgMeteo/${name}.png`
}