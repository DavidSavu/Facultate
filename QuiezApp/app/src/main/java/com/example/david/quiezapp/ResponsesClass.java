package com.example.david.quiezapp;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by David on 3/27/2016.
 */
public class ResponsesClass {

    String Respons;
    String Quiez;
    String id;
    ArrayList<ResponsesClass> x;

   public ResponsesClass()
    {
        x= new ArrayList<ResponsesClass>();
    }

    public void Add(String _Respons,String _Quiez,String _id)
    {
        Respons=_Respons;
        Quiez=_Quiez;
        id=_id;
        x.add(new ResponsesClass());
    }

    public ArrayList<ResponsesClass> getResonsesClass()
    {
     return x;
    }

    public int Count()
    {
        return  x.size();
    }
}
