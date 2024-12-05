import 'package:flutter/material.dart';
import 'package:flutter_dieren_app/widgets/navigation_bar.dart';

void main() {
  runApp(const DierenApp());
}

class DierenApp extends StatelessWidget {
  // This widget is the root of your application.
  const DierenApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'AR Dierentuin',
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(seedColor: Colors.green),
        useMaterial3: true,
      ),
      home: const NavigationBarWidget(),
    );
  }
}
