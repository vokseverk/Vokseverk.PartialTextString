import { LitElement, html, css } from '@umbraco-cms/backoffice/external/lit'

class PartialTextString extends LitElement {

	#internalValue = ''

	static properties = {
		value: {}
	}

	static styles = css`
		:host {
			display: flex;
			gap: 6px;
			align-items: center;
		}
	`

	set config(data) {
		this.prefixText = data.getValueByAlias('prefix') || null
		this.suffixText = data.getValueByAlias('suffix') || null
		this.inputPlaceholder = data.getValueByAlias('placeholder') || ''
		this.inputCss = data.getValueByAlias('inputCss') || ''
		this.preSuffixCss = data.getValueByAlias('preSuffixCss') || ''
	}

	render() {
		return html`
			${ this.prefixText ? html`<span class="prefix" style=${this.preSuffixCss}>${ this.prefixText }</span>` : '' }
			<uui-input style=${this.inputCss} placeholder=${this.inputPlaceholder} .value=${this.value} @input=${this.changed}></uui-input>
			${ this.suffixText ? html`<span class="suffix" style=${this.preSuffixCss}>${ this.suffixText }</span>` : '' }
		`
	}

	get value() {
		return this.#internalValue;
	}

	set value(newValue) {
		if (newValue != null && newValue != '') {
			this.#internalValue = newValue
			this.dispatchEvent(new CustomEvent('change'))
		}
	}

	changed(event) {
		this.value = event.target.value
	}

}

customElements.define('partial-textstring', PartialTextString)
