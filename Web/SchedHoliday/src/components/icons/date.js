import {format} from 'date-fns'
import {da} from "date-fns/locale";

export function convertEpochToDate(epoch){
    const date = new Date(epoch * 1000)
    return format(date, 'dd/MM/yyyy')
}

export function convertDateToEpoch(date){
    var dateObject = new Date(date)
    return dateObject.getTime() / 1000
}

export function convertEpochToDateAndHours(epoch){
    const date = new Date(epoch * 1000)
    return format(date, 'dd/MM/yyyy HH:mm')
}

export function convertEpochToDateCalender(epoch){
    const date = new Date(epoch * 1000)
    const year = date.getFullYear().toString();
    const month = (date.getMonth() + 1) < 10 ? "0" + (date.getMonth() + 1).toString() : (date.getMonth() + 1).toString();
    const day = date.getDate() < 10 ? "0" + date.getDate().toString() : date.getDate().toString();
    const hours = date.getHours() < 10 ? "0" + date.getHours().toString() : date.getHours().toString();
    const minutes = date.getMinutes() < 10 ? "0" +date.getMinutes().toString() : date.getMinutes().toString();

    return year + month + day + "T" + hours + minutes + "00";
    /*const date = new Date(epoch * 1000)
    return format(date, 'yyyyMMddThhmm00')*/
}

export function triCroissant(list){
    return list.slice().sort((a, b) => a.EpochStart - b.EpochStart)
}

export function triDecroissant(list){
    const tab = list.slice().sort((a, b) => b.EpochStart - a.EpochStart)
    return tab
}