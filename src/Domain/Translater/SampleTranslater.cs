using System;
using csmvvm.entity;
using csmvvm.repository;
using csmvvm.viewmodel;

namespace csmvvm.translater {

    public class SampleTranslater {

        public static SampleEntity TranslateSample1 (SampleResponse response) {
            SampleEntity entity = new SampleEntity ();
            System.Random r = new System.Random ();
            entity.Id = r.Next (10000);
            entity.Name = response.Result;
            return entity;
        }
    }
}