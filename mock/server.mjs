import express from "express";
import morgan from "morgan";
import log4js from "log4js";
import bodyParser from "body-parser";
import mongo, { objID } from "./mongo.mjs";

const logger = log4js.getLogger("system");
logger.level = "debug";

const app = express();
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());
app.use(log4js.connectLogger(logger, { level: "auto" }));
app.listen(3000);

const SAMPLE = "sample";

app.get("/sample", (req, res) => {
    mongo(SAMPLE).then(collection => {
        logger.debug(req.params.id, req.body);
        collection
            .find(req.body)
            .toArray()
            .then(r => {
                res.json(r);
            })
            .catch(err => {
                logger.error(err);
                res.send(err);
            });
    });
});

app.get("/sample/:id", (req, res) => {
    mongo(SAMPLE).then(collection => {
        logger.debug(req.params.id, req.body);
        collection
            .findOne({ _id: objID(req.params.id) })
            .then(r => {
                res.json(r);
            })
            .catch(err => {
                logger.error(err);
                res.send(err);
            });
    });
});

app.post("/sample", (req, res) => {
    mongo(SAMPLE).then(collection => {
        logger.debug(req.body);
        let row = req.body || {};
        if (!row.name) {
            res.send("validate error.");
        }
        collection
            .insertOne(row)
            .then(r => {
                res.json(r);
            })
            .catch(err => {
                logger.error(err);
                res.send(err);
            });
    });
});

app.put("/sample/:id", (req, res) => {
    mongo(SAMPLE).then(collection => {
        logger.debug(req.params.id, req.body);
        collection
            .findOneAndUpdate(
                { _id: objID(req.params.id) },
                { $set: req.body },
                { sort: { points: 1 }, upsert: true, returnNewDocument: true }
            )
            .then(r => {
                res.json(r);
            })
            .catch(err => {
                logger.error(err);
                res.send(err);
            });
    });
});

app.delete("/sample/:id", (req, res) => {
    mongo(SAMPLE).then(collection => {
        logger.debug(req.params.id, req.body);
        collection
            .findOneAndDelete({ _id: objID(req.params.id) }, {})
            .then(r => {
                res.json(r);
            })
            .catch(err => {
                logger.error(err);
                res.send(err);
            });
    });
});
