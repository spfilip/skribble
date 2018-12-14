package com.example.filip.lab_intents;

import android.content.Intent;
import android.content.pm.ResolveInfo;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.text.method.ScrollingMovementMethod;
import android.util.Log;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;

public class ImplicitActivity extends AppCompatActivity {

    TextView txt;
    private RecyclerView recyclerView;
    private RecyclerView.Adapter adapter;
    private List<ListItem> listItems;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_implicit);

//        txt = (TextView) findViewById(R.id.textView2);
        Intent intent = new Intent();
        intent.addCategory("android.intent.category.LAUNCHER");
        intent.setAction("android.intent.action.MAIN");

        List<ResolveInfo> infos = getPackageManager().queryIntentActivities(intent, 0);

        recyclerView = (RecyclerView) findViewById(R.id.recyclerView);
        recyclerView.setHasFixedSize(true);
        recyclerView.setLayoutManager(new LinearLayoutManager(this));

        listItems = new ArrayList<>();

        for (int i = 0; i < infos.size(); i++) {
            String[] s = infos.get(i).activityInfo.name.split("\\.");
            int size = s.length - 1;

            ListItem listItem = new ListItem(s[size]);

            listItems.add(listItem);
        }

        adapter = new MyAdapter(listItems,this);

        recyclerView.setAdapter(adapter);


//        for (int i = 0; i < infos.size(); i++) {
//            String[] s = infos.get(i).activityInfo.name.split("\\.");
//            int size = s.length - 1;
//            if (size > 0) {
//                if (i != 0)
//                    txt.append("\n");
//
//                txt.append(s[size]);
//            }
//
//        }

//        txt.setMovementMethod(new ScrollingMovementMethod());
    }
}
