import express from "express";
import bodyParser from "body-parser";
import ObjectID from "mongodb";
import mongo from "./mongo.mjs";

var app = express();
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());
app.listen(3000);

const SAMPLE = "sample";

app.get("/sample", (req, res) => {
  mongo(SAMPLE).then(collection => {
    collection.find().toArray((err, docs) => {
      res.json(docs);
    });
  });
});

app.post("/sample", (req, res) => {
  mongo(SAMPLE).then(collection => {
    let row = req.body || {};
    console.log(row);

    collection
      .insertOne(row)
      .then(r => {
        res.json(r);
      })
      .catch(err => {
        console.error(err);
        res.send(err);
      });
  });
});

app.put("/sample/:id", (req, res) => {
  mongo(SAMPLE).then(collection => {
    console.log(req.params.id, req.body);
    collection
      .findOneAndUpdate(
        { _id: req.params.id },
        { $set: req.body },
        { sort: { points: 1 }, upsert: true, returnNewDocument: true }
      )
      .then(r => {
        res.json(r);
      })
      .catch(err => {
        console.error(err);
        res.send(err);
      });
  });
});

app.delete("/sample/:id", (req, res) => {
  mongo(SAMPLE).then(collection => {
    console.log(req.params.id, req.body);
    collection
      .findOneAndDelete({ _id: req.params.id }, {})
      .then(r => {
        console.error(r);
        res.json(r);
      })
      .catch(err => {
        console.error(err);
        res.send(err);
      });
  });
});
