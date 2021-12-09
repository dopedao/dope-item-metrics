import fetch from 'isomorphic-fetch';
import itemScores from './outputs/itemScores.json';
import itemProbability from './outputs/itemProbabilities.json';

const baseUrl = 'https://api.thegraph.com/subgraphs/name/tarrencev/dope-wars-kovan-optimism';

interface ApiResponse {
    data: {
        hustler: {
            attributes: Items[];
        }
    }
}

interface Items {
    traitType: string;
    value: string;
}

function GetHustlerRaw(id: number): Promise<ApiResponse> {
    const data = {
        "query": `{
        hustler(id: ${id}) {
        attributes {
            traitType
            value
            }
        }
    }`,
        "variables": null
    };

    return fetch(baseUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data)
    })
        .then(res => {
            return res.json() as ApiResponse;
        });
}

type RarityBag = {
    Clothes: number,
    Feet: number,
    Hands: number,
    Neck: number,
    Ring: number,
    Waist: number,
    Weapon: number,
    Drug: number,
    Vehicle: number
}

let emptyBag: RarityBag = {
    Clothes: 0,
    Feet: 0,
    Hands: 0,
    Neck: 0,
    Ring: 0,
    Waist: 0,
    Weapon: 0,
    Drug: 0,
    Vehicle: 0
}

const getInventoryRarityScores = async (hustlerId: number) => {
    const rawHustler = await GetHustlerRaw(hustlerId);
    for (let item of rawHustler.data.hustler.attributes) {
        if (item.traitType in emptyBag) {
            emptyBag[item.traitType] = itemScores[item.value];
        }
    }
    return emptyBag;
}

const getInventoryProbabilities = async (hustlerId: number) => {
    const rawHustler = await GetHustlerRaw(hustlerId);
    for (let item of rawHustler.data.hustler.attributes) {
        if (item.traitType in emptyBag) {
            emptyBag[item.traitType] = itemProbability[item.value];
        }
    }
    return emptyBag;
}

//id in graphql query != Dope Id
getInventoryRarityScores(0).then(res => {
    console.log(res);
});

getInventoryProbabilities(0).then(res => {
    console.log(res);
});

export default getInventoryRarityScores;