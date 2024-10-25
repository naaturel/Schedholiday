export async function getKeyGoogle(route){
    try {
        const jsonFilePath = '../key.json';
        const response = await fetch(jsonFilePath);
        if (!response.ok) {
            throw new Error(`Erreur de récupération du fichier JSON : ${response.statusText}`);
        }
        return await response.json().then(data => {
            console.log(data)
            return data.googleMapsApiKey
        });
    } catch (error) {
        console.error('Une erreur s\'est produite :', error.toString());
        throw error;
    }
}

export async function getKeyMeteo(){
    try {
        const jsonFilePath = '../../key.json';
        const response = await fetch(jsonFilePath);
        if (!response.ok) {
            throw new Error(`Erreur de récupération du fichier JSON : ${response.statusText}`);
        }
        const jsonData = await response.json();
        return jsonData.MeteoKey;
    } catch (error) {
        console.error('Une erreur s\'est produite :', error);
        throw error;
    }
}