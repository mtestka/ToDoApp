import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { SharedStateProvider } from './SharedStateProvider';

export class Layout extends Component {
  static displayName = Layout.name;

  render() {
    return (
        <div className="mb-10">
            <SharedStateProvider>
                {this.props.children}
            </SharedStateProvider>
      </div>
    );
  }
}
