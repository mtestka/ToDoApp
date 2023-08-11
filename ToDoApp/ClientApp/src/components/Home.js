import React, { Component } from 'react';
import ToDoTasksContainer from './core/ToDoTasksContainer';
import Header from './Header';
import NotificationComponent from './NotificationComponent';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
        <div className="pt-[100px]">
            <Header />
            <NotificationComponent />
            <div className="max-w-xl mx-auto mt-4">
                <ToDoTasksContainer />
            </div>
        </div>
    );
  }
}
