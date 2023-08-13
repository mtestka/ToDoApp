import React, { Component } from 'react';
import { FiCheckCircle, FiCircle } from "react-icons/fi";
import { useSharedState } from '../SharedStateProvider';

function ToDoTask(props) {

    const { refreshFlag, setRefreshFlag } = useSharedState();

    let color = props.task.color == 1 ? "bg-blue-400" :
                props.task.color == 2 ? "bg-red-400" :
                props.task.color == 3 ? "bg-green-400" :
                props.task.color == 4 ? "bg-yellow-400" : "";

    const checkTask = async (e) => {
        e.stopPropagation();
        try {
            let res = await fetch('todo/' + props.task.id + '/Check', {
                method: 'PATCH'
            });

            if (res.status === 200) {
                setRefreshFlag(!refreshFlag);
            } else {
                console.log("There was an error!");
            }
        } catch (err) {
            console.log(err);
        }
    };

    const uncheckTask = async (e) => {
        e.stopPropagation();
        try {
            let res = await fetch('todo/' + props.task.id + '/Uncheck', {
                method: 'PATCH'
            });

            if (res.status === 200) {
                setRefreshFlag(!refreshFlag);
            } else {
                console.log("There was an error!");
            }
        } catch (err) {
            console.log(err);
        }
    };

    const openEditModal = (e) => {
        e.stopPropagation();
        props.handleOnClick(props.task.id);
    }

    return (
        <div className="w-full bg-white h-[80px] cursor-pointer shadow-sm hover:drop-shadow-xl rounded-2xl flex items-center justify-between px-4 py-2" onClick={openEditModal} >
            <div className="flex items-center">
                <div className={"mr-4 rounded-full w-[20px] h-[20px] " + color}>

                </div>
                <div className={"truncate text-xl " + (props.task.isCompleted?"line-through":"")}>
                    {props.task.name}
                </div>
            </div>
            <div>
                {!props.task.isCompleted &&
                    <button className="flex" onClick={checkTask}>
                        <FiCircle className="text-2xl text-gray-200 hover:text-gray-500" />
                    </button>
                }
                {props.task.isCompleted &&
                    <button className="flex" onClick={uncheckTask}>
                        <FiCheckCircle className="text-2xl text-green-400" />
                    </button>
                }
                
            </div>
        </div>
    );
}

export default ToDoTask;