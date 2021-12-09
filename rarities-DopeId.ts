import loot from './inputs/loot.json';
import itemScores from './outputs/itemScores.json';
import itemProbability from './outputs/itemProbabilities.json';

let attributes: Array<string> = ['clothes', 'foot', 'hand', 'neck', 'ring', 'waist', 'weapon', 'drugs', 'vehicle' ];

type RarityBag = {
    clothes: number,
    foot: number,
    hand: number,
    neck: number,
    ring: number,
    waist: number,
    weapon: number,
    drugs: number,
    vehicle: number
}

let emptyBag: RarityBag = {
    clothes: 0,
    foot: 0,
    hand: 0,
    neck: 0,
    ring: 0,
    waist: 0,
    weapon: 0,
    drugs: 0,
    vehicle: 0
}

const getItemRarityScores = (dopeId: number) => {
    for (let item of attributes) {
        emptyBag[item] = itemScores[loot[dopeId-1][dopeId][item]];
    }
    return emptyBag;
}

const getItemProbability = (dopeId: number) => {
    for (let item of attributes) {
        emptyBag[item] = itemProbability[loot[dopeId-1][dopeId][item]];
    }
    return emptyBag;
}

console.log(getItemRarityScores(1));
console.log(getItemProbability(1));