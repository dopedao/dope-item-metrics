import loot from "./inputs/loot.json";
import hustler from "./inputs/rarity-score.json";
import occurences from "./inputs/occurences.json"
import * as fs from "fs";

let attributes: Array<string> = ['clothes', 'foot', 'hand', 'neck', 'ring', 'waist', 'weapon', 'drugs', 'vehicle'];
const itemMap = new Map<string, number>();

for (let i = 0; i < 8000; i++) {
    for (let key of attributes) {
        itemMap.set(loot[i][i + 1][key], hustler[i].rarity[key]);
    }
}
const items = Object.fromEntries(itemMap);

fs.writeFile('outputs\\itemScores.json', JSON.stringify(items, null, 2), function (err) {
    if (err) throw err;
    console.log("Completed itemScores!");
});


itemMap.clear();

for (let value in occurences) {
    itemMap.set(value, occurences[value] / 80);
}
const itemProbabilities = Object.fromEntries(itemMap);

fs.writeFile('outputs\\itemProbabilities.json', JSON.stringify(itemProbabilities, null, 2), function (err) {
    if (err) throw err;
    console.log("Completed itemProbabilities!")
})