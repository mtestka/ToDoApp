import React, { Component } from 'react';
import { FiCheckCircle, FiCircle } from "react-icons/fi";

function ToDoTask(props) {

    let color = props.task.color == 1 ? "bg-blue-400" :
                props.task.color == 2 ? "bg-red-400" :
                props.task.color == 3 ? "bg-green-400" :
                props.task.color == 4 ? "bg-yellow-400" : "";

    return (
        <div className="w-full h-[80px] shadow rounded-2xl flex items-center justify-between px-4 py-2">
            <div className="flex items-center">
                <div className={"mr-4 rounded-full w-[20px] h-[20px] " + color}>

                </div>
                <div className="truncate text-xl">
                    {props.task.name}
                </div>
            </div>
            <div>
                <button className="flex">
                    <FiCircle className="text-2xl text-gray-200" />
                </button>
            </div>
        </div>
    );
}

export default ToDoTask;