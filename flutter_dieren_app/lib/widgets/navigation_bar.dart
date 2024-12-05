import 'package:flutter/material.dart';
import 'package:flutter_dieren_app/pages/account.dart';
import 'package:flutter_dieren_app/pages/animal_list.dart';
import 'package:flutter_dieren_app/pages/scan_animal.dart';
import 'package:flutter_dieren_app/pages/scoreboard.dart';

// Offical documentation for NavigationBar:
// https://api.flutter.dev/flutter/material/NavigationBar-class.html

class NavigationBarWidget extends StatefulWidget {
  const NavigationBarWidget({super.key});

  @override
  State<NavigationBarWidget> createState() => _NavigationBarWidgetState();
}

class _NavigationBarWidgetState extends State<NavigationBarWidget> {
  // Set default page to ScanAnimalPage
  int currentPageIndex = 1;

  // TODO: Get this from the AuthService
  bool isUserLoggedIn = false;

  // Number of newly discovered animals
  int newlyDiscoveredAnimals = 2;

  // List of pages for navigation
  final List<Widget> _pages = [
    const ScoreboardPage(),
    const ScanAnimalPage(),
    const AnimalListPage(),
    const AccountPage(),
  ];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      bottomNavigationBar: NavigationBar(
        onDestinationSelected: (int index) {
          setState(() {
            currentPageIndex = index;
          });
        },
        indicatorColor: Colors.amber,
        selectedIndex: currentPageIndex,
        destinations: [
          const NavigationDestination(
            selectedIcon: Icon(Icons.emoji_events),
            icon: Icon(Icons.emoji_events_outlined),
            label: 'Scoreboard',
          ),
          const NavigationDestination(
            selectedIcon: Icon(Icons.camera_alt),
            icon: Icon(Icons.camera_alt_outlined),
            label: 'Scan',
          ),
          NavigationDestination(
            selectedIcon: const Icon(Icons.pets),
            icon: Badge(
              isLabelVisible: newlyDiscoveredAnimals > 0,
              label: Text('$newlyDiscoveredAnimals'),
              child: const Icon(Icons.pets_outlined),
            ),
            label: 'Animals',
          ),
          NavigationDestination(
            selectedIcon: const Icon(Icons.person),
            icon: Badge(
              isLabelVisible: !isUserLoggedIn,
              label: const Text('!'),
              child: const Icon(Icons.person_outlined),
            ),
            label: 'Account',
          ),
        ],
      ),
      body: _pages[currentPageIndex],
    );
  }
}
