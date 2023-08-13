import React, { useState, useEffect } from 'react';
import ToDoTasksContainer from './core/ToDoTasksContainer';
import Header from './Header';
import NotificationComponent from './NotificationComponent';

function Home(){
    const [date, setDate] = useState("")
    const curr = new Date();

    useEffect(() => {
        setDate(curr.toISOString().substring(0, 10));
    },[])

    return (
        <div>
        {date &&
            <div className="pt-[100px]">
                <Header date={date} setDate={setDate} />
                <NotificationComponent />
                <div className="max-w-xl mx-auto mt-4">
                    <ToDoTasksContainer date={date} />
                </div>
            </div>
        }
        </div>
    );
}

export default Home;
