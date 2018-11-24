import MongoClient from "mongodb";
const url = "mongodb://127.0.0.1:27017/sample";

export const objID = id => MongoClient.ObjectID(id);

export default name => {
    return new Promise((resolve, reject) => {
        MongoClient.connect(url)
            .then(mongodb => {
                resolve(mongodb.db().collection(name));
            })
            .catch(err => {
                console.error(err);
                reject(err);
            });
    });
};

// mongod --dbpath data
// mongo
// use sample
